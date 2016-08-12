using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Cache;
using System;
using System.Globalization;
using WebApi.TraceInfo;
namespace WebApi.Controllers
{
    ///SET - > api/IAQCORE?name=PMDSensorAPI&serial=TESTBETA123&version=1.0.0&lic=ISC&author=PMT&value=PPM=500|PPB=25&cache=no
    ///GET - > api/IAQCORE?serial=TESTBETA123
    [Route("api/[controller]")]
    public class IAQCOREController : Controller
    {

        public IiAQCORE IiAQCOREs { get; set; }
        public IAQCOREController(IiAQCORE iaqcore){ IiAQCOREs = iaqcore; }

        public async Task<object> Get([FromQuery]string name,
            string serial, 
            string version,
            string lic,
            string author,
            string value,
            string cache)
        {
            return await Task.Run(async () => {
                try
                {
                    var cacheKey = $"sensor:{serial}:IAQCORE";                  
                    await AddCorOptions();
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(cacheKey);
                    var jsonResults = await CacheMemory.Get<IAQCORE>(cacheKey);
                    if (jsonResults != null) return jsonResults;
                    var sensor = await IiAQCOREs.Get(serial, value);
                    sensor.LastRecord = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                    sensor.Version = version ?? string.Empty;
                    sensor.Lic = lic ?? string.Empty;
                    sensor.Author = author ?? string.Empty;
                    sensor.Name = name ?? string.Empty;
                    await CacheMemory.SetAndExpiresSeconds(cacheKey, sensor, 30);
                    return sensor;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("IAQCOREController:Get", ex);
                    return null;
                }
            });
        }
        private async Task AddCorOptions()
        {
            await Task.Run(() =>
            {
                Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                Response.Headers.Add("Access-Control-Allow-Headers",
                    new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            });
        }
    }
}
