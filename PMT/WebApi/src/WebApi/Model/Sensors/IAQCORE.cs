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

        public int Measurement { get; set; } = 0;
        public int LowLimit { get; set; } = 500;
        public string LowLimitMsg { get; set; }
        public int HighLimit { get; set; } = 1200;   
        public string HighLimitMsg { get; set; }

    }

    public class PPB
    {

        public int Measurement { get; set; } = 0;
        public int LowLimit { get; set; } = 500;
        public string LowLimitMsg { get; set; }
        public int HighLimit { get; set; } = 1200;
        public string HighLimitMsg { get; set; }

    }
}
