using WebApi.Queue;
namespace WebApi.Model
{
   
    public class COREALL
    {

        public string Name { get; set; }
        public string Model { get; set; } = "COREALL";
        public string Version { get; set; }
        public string Serial { get; set; }
        public string Value { get; set; }
        public string Author { get; set; }
        public string Lic { get; set; }
        public decimal Fahrenheit { get; set; }
        public FixedQueue<decimal> FahrenheitHistogram { get; set; } = new FixedQueue<decimal>();

        public decimal Celcius { get; set; }
        public FixedQueue<decimal> CelciusHistogram { get; set; } = new FixedQueue<decimal>();

        public decimal Kelvin { get; set; }
        public FixedQueue<decimal> KelvinHistogram { get; set; } = new FixedQueue<decimal>();

        public decimal Humidity { get; set; }
        public FixedQueue<decimal> HumidityHistogram { get; set; } = new FixedQueue<decimal>();


        public decimal MaxTempLimit { get; set; } = Startup.AppSettings.LimitSettings.Temperature.Max;
        public decimal LowTempLimit { get; set; } = Startup.AppSettings.LimitSettings.Temperature.Low;
        public string TemperatureMsg { get; set; } = Startup.AppSettings.LimitSettings.Temperature.Msg.Value;

        public decimal MaxHumidityLimit { get; set; } =  Startup.AppSettings.LimitSettings.Humidity.Max;
        public decimal LowHumidityLimit { get; set; } =  Startup.AppSettings.LimitSettings.Humidity.Low;
        public string HumidityMsg { get; set; } = Startup.AppSettings.LimitSettings.Humidity.Msg.Value;


        public PPM PPM { get; set; } = new PPM();
        

        public PPB PPB { get; set; } = new PPB();
        public string Notification { get; set; }
        public bool EnableLimitVerification { get; set; } = Startup.AppSettings.LimitSettings.Enabled;
        public string LastRecord { get; set; }


    }
}
