using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                             optional: true,
                             reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var connString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlite(connString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Beverages" },
                    new Category { Id = 2, Name = "Condiments" },
                    new Category { Id = 3, Name = "Confections" },
                    new Category { Id = 4, Name = "Dairy products" },
                    new Category { Id = 5, Name = "Grains/Cereals" },
                    new Category { Id = 6, Name = "Meat/Poultry" },
                    new Category { Id = 7, Name = "Produce" },
                    new Category { Id = 8, Name = "Seafood" }
                );

            builder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "CocaCola",
                        CategoryId = 1,
                        UnitPrice = 10000,
                        UnitsInStock = 5
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Milo",
                        CategoryId = 4,
                        UnitPrice = 8000,
                        UnitsInStock = 10
                    }
                );
        }
    }
}
