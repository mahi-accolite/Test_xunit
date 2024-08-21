using Microsoft.AspNetCore.Mvc;
using UnitTestMoqFinal.Models;
using UnitTestMoqFinal.Services;
using System;

using System.Net.Http;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestMoqFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string url = "https://spotify-demo-api-fe224840a08c.herokuapp.com/v1/browse/featured-playlists";

        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet("productlist")]
        public IEnumerable<Product> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;

        }
        [HttpGet("getproductbyid")]
        public async Task<Product> GetProductById(int Id)
        {
            return productService.GetProductById(Id);
        }

        [HttpGet("MusicMatcher")]
        public async Task<FeaturedPlaylists> MusicMatcher()
        {
            return await productService.MusicList();
        }

        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            return productService.AddProduct(product);
        }

        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }
    }
}
