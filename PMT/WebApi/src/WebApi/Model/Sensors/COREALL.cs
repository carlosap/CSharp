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
        public decimal Celcius { get; set; }
        public decimal Kelvin { get; set; }
        public decimal Humidity { get; set; }
        public PPM PPM { get; set; } = new PPM();
        public PPB PPB { get; set; } = new PPB();
        public string LastRecord { get; set; }

    }
}
