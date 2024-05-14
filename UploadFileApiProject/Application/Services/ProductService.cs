using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UploadFileApiProject.Application.Contracts;
using UploadFileApiProject.Application.Dtos;
using UploadFileApiProject.Infrastructure;

namespace UploadFileApiProject.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(IApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _dbContext.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
