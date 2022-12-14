using IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productlist = new List<Product>
            {
                new Product{Id=1,Name="Kalem",Price=10,Stock=20},
                new Product{Id=2,Name="Kaðýt",Price=2,Stock=20},
                new Product{Id=3,Name="Silgi",Price=1,Stock=20},
            };
            return Ok(productlist);
        }
        [HttpGet("{id}")]
        [Authorize(Policy ="UpdateOrCreate")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"{id} güncellendi");
        }
        [HttpPost]
        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult Create(Product product) => Ok(product);
    }
}