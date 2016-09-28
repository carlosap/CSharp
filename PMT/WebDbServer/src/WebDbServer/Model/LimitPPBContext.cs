using System;
using Microsoft.EntityFrameworkCore;
namespace WebDbServer.Model
{
    public class LimitPPBContext : DbContext
    {
        public LimitPPBContext(DbContextOptions<LimitPPBContext> options) : base(options){}
        public DbSet<PPB> PPB { get; set; }

    }
    public class PPB
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