using Microsoft.AspNetCore.Mvc;
using UploadFileApiProject.Application.Contracts;
using UploadFileApiProject.Framework;

namespace UploadFileApiProject.Controllers
{
    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }
    }
}
