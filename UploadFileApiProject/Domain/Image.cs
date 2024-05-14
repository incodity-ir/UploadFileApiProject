namespace UploadFileApiProject.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public string ContentType { get; set; }

        //navigation properties
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}
