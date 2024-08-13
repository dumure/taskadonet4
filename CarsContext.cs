using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskadonet4
{
    internal class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
Database=Cars; 
Integrated Security=SSPI");
        }
    }
}
