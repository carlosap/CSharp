using WebApi.Queue;

namespace WebApi.Model
{
    public class IAQCORE
    {
        public string Name { get; set; }
        public string Model { get; set; } = "IAQCORE";
        public string Version { get; set; }
        public string Serial { get; set; }
        public string Value { get; set; }
        public string Author { get; set; }
        public string Lic { get; set; }
        public string LastRecord { get; set; }
        public PPM PPM { get; set; } = new PPM();
        public PPB PPB { get; set; } = new PPB();
    }

    public class PPM
    {

        public decimal Measurement { get; set; } = 500;
        public FixedQueue<decimal> Histogram { get; set; } = new FixedQueue<decimal>();
        public decimal MaxLimit { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPM.Max;
        public decimal LowLimit { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPM.Low;
        public string Msg { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPM.Msg.Value;

    }

    public class PPB
    {
        public decimal Measurement { get; set; } = 500;
        public decimal MaxLimit { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPB.Max;
        public decimal LowLimit { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPB.Low;
        public string Msg { get; set; } = Startup.AppSettings.LimitSettings.VOC.PPB.Msg.Value;
    }
}
