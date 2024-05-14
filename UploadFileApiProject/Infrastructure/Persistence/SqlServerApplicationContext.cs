using Microsoft.EntityFrameworkCore;
using UploadFileApiProject.Domain;
using UploadFileApiProject.Infrastructure.Configuration;

namespace UploadFileApiProject.Infrastructure.Persistence
{
    public class SqlServerApplicationContext:DbContext,IApplicationContext
    {

        public SqlServerApplicationContext(DbContextOptions<SqlServerApplicationContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductImageConfiguration).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
