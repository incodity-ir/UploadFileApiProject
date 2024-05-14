namespace UploadFileApiProject.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation properties
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}
