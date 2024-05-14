using UploadFileApiProject.Application.Dtos;

namespace UploadFileApiProject.Application.Contracts
{
    public interface IPictureService
    {
        Task<ImageDto> UploadImage(ImageUploadDto image);
        Task<ImageDto> UploadImageBase64(ImageBase64UploadDto fileBase64);
        Task<ImageDto> GetById(int id);
        Task<bool> IsExist(int id);
    }
}
