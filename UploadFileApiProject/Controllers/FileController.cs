using Microsoft.AspNetCore.Mvc;
using UploadFileApiProject.Application.Contracts;
using UploadFileApiProject.Application.Dtos;
using UploadFileApiProject.Framework;

namespace UploadFileApiProject.Controllers
{
    public class FileController: ApiBaseController
    {
        private readonly IPictureService _pictureService;

        public FileController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("All IMages");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id == null) return BadRequest();
            if (await _pictureService.IsExist(Id) == false) return NotFound();
            var image = await _pictureService.GetById(Id);

            return PhysicalFile(image.VirtualPath, image.ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] ImageUploadDto image)
        {
            var ImageContentType = new List<string>()
            {
                "image/jpg",
                "image/gif",
                "image/png",
                "image/jpeg"
            } as IReadOnlyCollection<string>;

            var ImageExtensionType = new List<string>()
            {
                ".jpg",
                ".png",
                ".gif",
                ".jpeg"

            } as IReadOnlyCollection<string>;


            var contentType = image.File.ContentType;
            var fileExtension = Path.GetExtension(image.File.FileName);

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.ToLower();
            }

            if (!ImageContentType.Contains(contentType) || !ImageExtensionType.Contains(fileExtension))
                return BadRequest();

            image.ContentType = contentType;
            image.MimeType = fileExtension;

            var ImageDto = await _pictureService.UploadImage(image);


            return CreatedAtAction(nameof(GetById),new { Id = ImageDto.Id},ImageDto);
        }

        [HttpPost("Base64String")]
        public async Task<IActionResult> UploadBas64Async([FromForm] ImageBase64UploadDto fileBase64StringDto)
        {
            if(string.IsNullOrEmpty(fileBase64StringDto.File)) return BadRequest();

            var formatFile = fileBase64StringDto.File.Split(",")[0];


            try
            {
                var buffer = Convert.FromBase64String(fileBase64StringDto.File.Split(",")[1]);
                MemoryStream ms = new(buffer);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }  
            
            var ImageContentType = new List<string>()
            {
                "image/jpg",
                "image/gif",
                "image/png",
                "image/jpeg"
            } as IReadOnlyCollection<string>;

            var ImageExtensionType = new List<string>()
            {
                ".jpg",
                ".png",
                ".gif",
                ".jpeg"

            } as IReadOnlyCollection<string>;




            var contentType = ImageContentType.FirstOrDefault(p => formatFile.Contains(p));

            if (contentType == null)
            {
                return BadRequest();
            }


            var fileExtension = ImageExtensionType.FirstOrDefault(p => formatFile.Contains(p.Replace(".", "")));
                

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.ToLower();
            }

            if (!ImageContentType.Contains(contentType) || !ImageExtensionType.Contains(fileExtension))
                return BadRequest();

            fileBase64StringDto.ContentType = contentType;
            fileBase64StringDto.MimeType = fileExtension;
            fileBase64StringDto.File = fileBase64StringDto.File.Split(",")[1];

            var ImageDto = await _pictureService.UploadImageBase64(fileBase64StringDto);


            return CreatedAtAction(nameof(GetById), new { Id = ImageDto.Id }, ImageDto);
        }
    }
}
