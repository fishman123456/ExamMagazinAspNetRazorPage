using ExamMagazinAspNetRazorPage.DB;
using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Service;
using ExamMagazinAspNetRazorPage.Storage;

using Microsoft.AspNetCore.Mvc;

namespace ExamMagazinAspNetRazorPage.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            
            _productService = productService;
        }
        [HttpGet]
        public async Task<List<Product>> ListAll()
        {
            return await _productService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Product?> GetById(int id)
        {
            Product? product = await _productService.GetById(id);
            if (product == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return product;
        }
        [HttpPost]
        public async Task<Product?> Add(Product product)
        {
            Product? result = await _productService.Add(product);
            if (result == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return result;
        }

        [HttpDelete("{id:int}")]
        public async Task<Product?> RemoveById(int id)
        {
            Product? product = await _productService.RemoveById(id);
            if (product == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return product;
        }

        [HttpPost("{id:int}")]
        public async Task<Product?> UpdateById(int id, Product product)
        {
            Product? updated = await _productService.UpdateById(id, product);
            if (updated == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return updated;
        }
    }
}
