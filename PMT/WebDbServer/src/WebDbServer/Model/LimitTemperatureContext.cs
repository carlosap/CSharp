using System;
using Microsoft.EntityFrameworkCore;
namespace WebDbServer.Model
{
    public class LimitTemperatureContext : DbContext
    {
        public LimitTemperatureContext(DbContextOptions<LimitTemperatureContext> options) : base(options){}
        public DbSet<Temperature> Temperature { get; set; }
    }
    public class Temperature
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