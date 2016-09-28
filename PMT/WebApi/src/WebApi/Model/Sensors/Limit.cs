using System;
namespace WebApi.Model.Sensors
{
    public class Limit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Low { get; set; }
        public string Msg { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
