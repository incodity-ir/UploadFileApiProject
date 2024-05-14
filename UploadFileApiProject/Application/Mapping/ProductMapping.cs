using AutoMapper;
using UploadFileApiProject.Application.Dtos;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Application.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
