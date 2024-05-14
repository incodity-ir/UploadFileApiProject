using Microsoft.EntityFrameworkCore;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Infrastructure
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
