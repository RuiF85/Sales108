using Microsoft.EntityFrameworkCore;
using Sales108.Web.Data.Entities;

namespace Sales108.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Country>()
            .HasIndex(c => c.Name)
            .IsUnique();              //NOME UNICO

            modelBuilder.Entity<Country>()
             .HasIndex(c => c.Name)
             .IsUnique();
        }
    }

}
