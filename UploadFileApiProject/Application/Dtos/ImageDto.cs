namespace UploadFileApiProject.Application.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string? ContentType { get; set; }
        public string VirtualPath { get; set; }
    }

    public class ImageUploadDto
    {
        public IFormFile File { get; set; }
        public string? ContentType { get; set; }
        public string? MimeType { get; set; }
    }

    public class ImageBase64UploadDto
    {
        public string File { get; set; }
        public string? ContentType { get; set; }
        public string? MimeType { get; set; }
    }
}
