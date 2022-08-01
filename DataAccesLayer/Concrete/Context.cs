using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=CamlicaBarkodCallCenterDBY;integrated security=true");
        }
        public DbSet<Authority>? Authority { get; set; }
        public DbSet<Customer>? Customers { get; set; }            
        public DbSet<LogCall>? logCalls { get; set; }
        public DbSet<Worker>? Worker { get; set; }
        public DbSet<Job>? Jobs { get; set; }
    }
}
