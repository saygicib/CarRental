using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true");//@ => \ bu işreti tek algılaması için yazıldı.
        }
        public DbSet<Car> tblCar { get; set; }
        public DbSet<Brand> tblBrand { get; set; }
        public DbSet<Color> tblColor { get; set; }
    }
}
