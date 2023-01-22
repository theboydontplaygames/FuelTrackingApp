using Fuel_Tracking_application.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fuel_Tracking_application.Data
{
    public class FuelDbContext : DbContext
    {
        public FuelDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet <Fuel> FuelData { get; set; }
    }
} 
