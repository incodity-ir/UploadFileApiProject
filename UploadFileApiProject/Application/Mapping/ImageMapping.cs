using AutoMapper;
using UploadFileApiProject.Application.Dtos;
using UploadFileApiProject.Domain;

namespace UploadFileApiProject.Application.Mapping
{
    public class ImageMapping:Profile
    {
        public ImageMapping()
        {
            CreateMap<Image, ImageDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.VirtualPath, opt => opt.MapFrom(src => src.Path));

        }
    }
}
