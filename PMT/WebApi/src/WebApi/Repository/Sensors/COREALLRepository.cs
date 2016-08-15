using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Model;
namespace WebApi.Repository
{
    public class COREALLRepository : ICOREALL
    {
        public async Task<COREALL> Get(string serial, string value)
        {
            return await Task.Run(async () =>
            {
                //TEMP: could changed to DB
                await Task.Delay(10);
                var sensor = new COREALL()
                {
                    Serial = serial,
                    Value = value
                };
                if (!value.Contains("|")) return sensor;

                var measurements = value.Split('|');
                foreach (var measurement in measurements)
                {
                    if (measurement.ToLower().Contains("fahrenheit"))
                        sensor.Fahrenheit = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("celsius"))
                        sensor.Celcius = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("kelvin"))
                        sensor.Kelvin = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("humidity"))
                        sensor.Humidity = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

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


