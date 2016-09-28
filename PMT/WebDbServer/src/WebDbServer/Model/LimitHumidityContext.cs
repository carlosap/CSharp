using System;
using Microsoft.EntityFrameworkCore;
namespace WebDbServer.Model
{
    public class LimitHumidityContext : DbContext
    {
        public LimitHumidityContext(DbContextOptions<LimitHumidityContext> options) : base(options){}
        public DbSet<Humidity> Humidity { get; set; }
    }
    public class Humidity
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