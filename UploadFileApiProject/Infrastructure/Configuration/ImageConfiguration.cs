using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Infrastructure.Configuration
{
    public class ImageConfiguration:IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            
        }
    }
}
