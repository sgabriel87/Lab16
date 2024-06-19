using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Models;
using Microsoft.EntityFrameworkCore;

namespace Car.Models
{
    public class CarDbContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\cursC#\Lab16\Vehicle\Car.mdf;Integrated Security=True");
        }
    }
}