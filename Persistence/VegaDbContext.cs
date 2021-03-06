using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class VegaDbContext : DbContext
    {

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options): 
            base(options)
        {

        }

        // Composite Primary Key w/ Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
            new {vf.VehicleId, vf.FeatureId}); 
        }
    }
}