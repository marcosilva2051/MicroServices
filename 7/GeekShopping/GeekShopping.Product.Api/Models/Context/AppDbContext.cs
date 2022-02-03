using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.Api.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<GeekShopping.ProductApi.Models.Product> Products { get; set; }
    }
}
