using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Model;
namespace WebApi.Repository
{
    public class IAQCORERepository : IiAQCORE
    {
        public async Task<IAQCORE> Get(string serial, string value)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(10);
                var sensor = new IAQCORE
                {
                    Serial = serial,
                    Value = value
                };
                if (!value.Contains("|")) return sensor;
                var measurements = value.Split('|');
                foreach (var measurement in measurements)
                {
                    if (measurement.ToLower().Contains("ppm"))
                        sensor.PPM.Measurement = int.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("ppb"))
                        sensor.PPB.Measurement = int.Parse(measurement.Split('=').GetValue(1).ToString());
                }
                return sensor;
            });
        }
    }
}


