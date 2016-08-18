using System.Text;
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

                var msgBuilder = new StringBuilder();
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
                    {
                        sensor.Fahrenheit = decimal.Parse(measurement.Split('=').GetValue(1).ToString());
                        if (!(sensor.Fahrenheit > sensor.LowTempLimit && sensor.Fahrenheit <= sensor.MaxTempLimit))
                            msgBuilder.Append($"{sensor.TemperatureMsg} ({sensor.Fahrenheit}). ");
                        
                    }
                        
                    if (measurement.ToLower().Contains("celsius"))
                        sensor.Celcius = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("kelvin"))
                        sensor.Kelvin = decimal.Parse(measurement.Split('=').GetValue(1).ToString());

                    if (measurement.ToLower().Contains("humidity"))
                    {
                        sensor.Humidity = decimal.Parse(measurement.Split('=').GetValue(1).ToString());
                        if (!(sensor.Humidity > sensor.LowHumidityLimit && sensor.Humidity <= sensor.MaxHumidityLimit))
                            msgBuilder.Append($"{sensor.HumidityMsg} ({sensor.Humidity}). ");
                    }


                    if (measurement.ToLower().Contains("ppm"))
                    {
                        sensor.PPM.Measurement = int.Parse(measurement.Split('=').GetValue(1).ToString());
                        if (!(sensor.PPM.Measurement > sensor.PPM.LowLimit && sensor.PPM.Measurement <= sensor.PPM.MaxLimit))
                            msgBuilder.Append($"{sensor.PPM.Msg} ({sensor.PPM.Measurement}). ");

                    }


                    if (measurement.ToLower().Contains("ppb"))
                    {
                        sensor.PPB.Measurement = int.Parse(measurement.Split('=').GetValue(1).ToString());
                        if (!(sensor.PPB.Measurement > sensor.PPB.LowLimit && sensor.PPB.Measurement <= sensor.PPB.MaxLimit))
                            msgBuilder.Append($"{sensor.PPB.Msg} ({sensor.PPB.Measurement}). ");
                    }
                        

                }
                sensor.Notification = msgBuilder.ToString();
                await NotifyLimits(sensor);
                return sensor;
            });

        }

        public async Task NotifyLimits(COREALL sensor)
        {
            await Task.Run(async () =>
            {
                if (sensor == null) return;
                if (!sensor.EnableLimitVerification) return;
                if (string.IsNullOrWhiteSpace(sensor.Notification)) return;
                var sms = new SendSmsRepository();
                var email = new SendEmailRepository();
                await email.SendHtml(sensor.Notification, "email");
                sms.Send(sensor.Notification);
                
            });
        }
    }
}


