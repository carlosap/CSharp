using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Model;
namespace WebApi.Repository
{
    public class Ens210Repository : IEns210
    {
        public async Task<ENS210> Get(string serial, string value)
        {
            return await Task.Run(async () =>
            {
                //TEMP: could changed to DB
                await Task.Delay(10);
                var sensor = new ENS210
                {
                    Serial = serial,
                    Value = value
                };
                if (!value.Contains("|")) return sensor;

                var measurements = value.Split('|');
                foreach (var measurement in measurements)
                {
                    if (measurement.ToLower().Contains("fahrenheit"))
                        sensor.Fahrenheit = measurement.Split('=').GetValue(1).ToString();

                    if (measurement.ToLower().Contains("celsius"))
                        sensor.Celcius = measurement.Split('=').GetValue(1).ToString();

                    if (measurement.ToLower().Contains("kelvin"))
                        sensor.Kelvin = measurement.Split('=').GetValue(1).ToString();

                    if (measurement.ToLower().Contains("humidity"))
                        sensor.Humidity = measurement.Split('=').GetValue(1).ToString();

                }
                return sensor;
            });
        }
    }
}


