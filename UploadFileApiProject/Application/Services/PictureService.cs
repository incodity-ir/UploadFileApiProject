using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadFileApiProject.Application.Contracts;
using UploadFileApiProject.Application.Dtos;
using UploadFileApiProject.Domain;
using UploadFileApiProject.Infrastructure;

namespace UploadFileApiProject.Application.Services
{
    public class PictureService:IPictureService
    {
        private readonly IApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public PictureService(IApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ImageDto> UploadImage(ImageUploadDto image)
        {
            var picture = new Image();
            picture.MimeType = image.MimeType;
            picture.ContentType = image.ContentType;
            picture.Path = "";
            await AddAsync(picture);

            var filename = $"{picture.Id:000000}_0{image.MimeType}";

            byte[] pictureBinary =null;
            using (var fileStream = image.File.OpenReadStream())
            {
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    pictureBinary = ms.ToArray();
                }
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);

            await File.WriteAllBytesAsync(filePath, pictureBinary);

            picture.Path = filePath;
            await Update(picture);

            ImageDto imageDto = new()
            {
                VirtualPath = picture.Path,
                Id = picture.Id
            };

            return imageDto;
        }


        public async Task<ImageDto> UploadImageBase64(ImageBase64UploadDto fileBase64)
        {
            var image = new Image();
            image.MimeType = fileBase64.MimeType;
            image.ContentType = fileBase64.ContentType;
            image.Path = "";
            await AddAsync(image);

            var filename = $"{image.Id:000000}_0{fileBase64.MimeType}";

            byte[] pictureBinary =Convert.FromBase64String(fileBase64.File);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);

            await File.WriteAllBytesAsync(filePath, pictureBinary);

            image.Path = filePath;
            await Update(image);

            ImageDto imageDto = new()
            {
                VirtualPath = image.Path,
                Id = image.Id
            };

            return imageDto;
        }

        public async Task<ImageDto> GetById(int id)
        {
            var image = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ImageDto>(image);
        }

        public async Task<bool> IsExist(int id)
        {
            var image = await GetById(id);
            return (image != null) ? true : false;
        }

        private async Task AddAsync(Image image)
        {
            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();
        }

        private async Task Update(Image image)
        {
             _dbContext.Images.Update(image);
            await _dbContext.SaveChangesAsync();
        }
    }
}
