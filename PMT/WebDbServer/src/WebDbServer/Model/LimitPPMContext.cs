using System;
using Microsoft.EntityFrameworkCore;
namespace WebDbServer.Model
{
    public class LimitPPMContext : DbContext
    {
        public LimitPPMContext(DbContextOptions<LimitPPMContext> options) : base(options){}
        public DbSet<PPM> PPM { get; set; }
    }
    public class PPM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Max { get; set; }
        public int Low { get; set; }
        public string Msg { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}