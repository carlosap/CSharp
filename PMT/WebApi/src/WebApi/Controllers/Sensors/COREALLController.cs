using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Cache;
using System;
using System.Globalization;
using WebApi.Queue;
using WebApi.TraceInfo;
namespace WebApi.Controllers
{
    ///SET - > api/COREALL?name=PMDSensorAPI&serial=TESTBETA123&version=1.0.0&lic=ISC&author=PMT&value=fahrenheit=88.45|celsius=85.80|kelvin=298.95|humidity=84.82|ppm=323|ppb=424&cache=no
    ///GET - > api/COREALL?serial=TESTBETA123
    [Route("api/[controller]")]
    public class COREALLController : Controller
    {

        public ICOREALL ICoreall { get; set; }
        public COREALLController(ICOREALL icoreall){ ICoreall = icoreall; }
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
                    var cacheKey = $"sensor:{serial}:ENS210";    
                    var fehrenheitQueueKey = $"fehrenheitListKey:{serial}:ENS210";
                    var celciusQueueKey = $"celciusListKey:{serial}:ENS210";
                    var kelvinQueueKey = $"kelvinListKey:{serial}:ENS210";
                    var humidityQueueKey = $"humidityListKey:{serial}:ENS210";
                    var ppmQueueKey = $"ppmListKey:{serial}:ENS210";

                    await AddCorOptions();
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(cacheKey);
                    var jsonResults = await CacheMemory.Get<COREALL>(cacheKey);
                    if (jsonResults != null) return jsonResults;
                    var sensor = await ICoreall.Get(serial, value);
                    sensor.LastRecord = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                    sensor.Version = version ?? string.Empty;
                    sensor.Lic = lic ?? string.Empty;
                    sensor.Author = author ?? string.Empty;
                    sensor.Name = name ?? string.Empty;
                    await GetFehrenheitHistogram(fehrenheitQueueKey, sensor);
                    await GetCelciusHistogram(celciusQueueKey, sensor);
                    await GetKelvinHistogram(kelvinQueueKey, sensor);
                    await GetHumidityHistogram(humidityQueueKey, sensor);
                    await GetPpmHistogram(ppmQueueKey, sensor);

                    await CacheMemory.SetAndExpiresDays(cacheKey, sensor, 1);
                    return sensor;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("COREALLController:Get", ex);
                    return null;
                }
            });
        }

        private static async Task GetFehrenheitHistogram(string fehrenheitQueueKey, COREALL sensor)
        {
            var fehrenheitQueueTemp = await CacheMemory.Get<FixedQueue<decimal>>(fehrenheitQueueKey) ??
                                      new FixedQueue<decimal>();

            fehrenheitQueueTemp.Enqueue(sensor.Fahrenheit);
            await CacheMemory.SetAndExpiresDays(fehrenheitQueueKey, fehrenheitQueueTemp, 1);
            sensor.FahrenheitHistogram = fehrenheitQueueTemp;
        }

        private static async Task GetCelciusHistogram(string celciusQueueKey, COREALL sensor)
        {
            var celciusQueueTemp = await CacheMemory.Get<FixedQueue<decimal>>(celciusQueueKey) ??
                                      new FixedQueue<decimal>();

            celciusQueueTemp.Enqueue(sensor.Celcius);
            await CacheMemory.SetAndExpiresDays(celciusQueueKey, celciusQueueTemp, 1);
            sensor.CelciusHistogram = celciusQueueTemp;
        }

        private static async Task GetKelvinHistogram(string kelvinQueueKey, COREALL sensor)
        {
            var kelvkinQueueTemp = await CacheMemory.Get<FixedQueue<decimal>>(kelvinQueueKey) ??
                                      new FixedQueue<decimal>();

            kelvkinQueueTemp.Enqueue(sensor.Kelvin);
            await CacheMemory.SetAndExpiresDays(kelvinQueueKey, kelvkinQueueTemp, 1);
            sensor.KelvinHistogram = kelvkinQueueTemp;
        }

        private static async Task GetHumidityHistogram(string humidityQueueKey, COREALL sensor)
        {
            var humidityQueueTemp = await CacheMemory.Get<FixedQueue<decimal>>(humidityQueueKey) ??
                                      new FixedQueue<decimal>();

            humidityQueueTemp.Enqueue(sensor.Humidity);
            await CacheMemory.SetAndExpiresDays(humidityQueueKey, humidityQueueTemp, 1);
            sensor.HumidityHistogram = humidityQueueTemp;
        }

        private static async Task GetPpmHistogram(string ppmQueueKey, COREALL sensor)
        {
            var ppmQueueTemp = await CacheMemory.Get<FixedQueue<int>>(ppmQueueKey) ??
                                      new FixedQueue<int>();

            ppmQueueTemp.Enqueue(sensor.PPM.Measurement);
            await CacheMemory.SetAndExpiresDays(ppmQueueKey, ppmQueueTemp, 1);
            sensor.PPM.Histogram = ppmQueueTemp;
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
