using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Infrastructure.Configuration
{
    public class ProductImageConfiguration:IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(p => new { p.ImageId, p.ProductId });
        }
    }
}
