namespace UploadFileApiProject.Domain
{
    public class ProductImage
    {
        public int ProductId { get; set; }
        public int ImageId { get; set; }   

        //navigation properties
        public Image Image { get; set; }
        public Product Product { get; set; }
    }
}
