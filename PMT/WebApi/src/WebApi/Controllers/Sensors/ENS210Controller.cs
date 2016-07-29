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
    ///SET - > api/ENS210?name=PMDSensorAPI&serial=TESTBETA123&version=1.0.0&lic=ISC&author=PMT&value=fahrenheit=78.45f|celsius=25.80c|kelvin=298.95k|humidity=44.82&cache=no
    ///GET - > api/ENS210?serial=TESTBETA123
    [Route("api/[controller]")]
    public class ENS210Controller : Controller
    {

        public ISensor Sensors { get; set; }
        public ENS210Controller(ISensor sensor){Sensors = sensor;}

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
                    var cacheKey = $"sensor:{serial}";                  
                    await AddCorOptions();
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(cacheKey);
                    var jsonResults = await CacheMemory.Get<ENS210>(cacheKey);
                    if (jsonResults != null) return jsonResults;
                    var sensor = await Sensors.Get(serial, value);
                    sensor.LastRecord = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                    sensor.Version = version ?? string.Empty;
                    sensor.Lic = lic ?? string.Empty;
                    sensor.Author = author ?? string.Empty;
                    sensor.Name = name ?? string.Empty;
                    await CacheMemory.SetAndExpiresDays(cacheKey, sensor, 1);
                    return sensor;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("ENS210Controller:Get", ex);
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
