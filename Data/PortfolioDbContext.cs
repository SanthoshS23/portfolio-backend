using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {
        }

        public DbSet<DbData> DbData { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbData>()
                .HasIndex(d => d.Key)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
