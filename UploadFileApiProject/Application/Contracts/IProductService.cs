using UploadFileApiProject.Application.Dtos;

namespace UploadFileApiProject.Application.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
