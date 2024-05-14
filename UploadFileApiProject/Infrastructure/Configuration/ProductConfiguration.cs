using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Infrastructure.Configuration
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(products);
        }

        public IEnumerable<Product> products => new[]
        {
            new Product()
            {
                Id = 1,
                Name = "IPhone15"
            },
            new Product()
            {
                Id = 2,
                Name = "Samsung S24"
            },
            new Product()
            {
                Id = 3,
                Name = "Samsung S23"
            }
        };
    }
}
