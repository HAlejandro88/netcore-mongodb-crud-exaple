using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using mongodb_api.Models;
using mongodb_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongodb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();
       
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }

           await db.InsertProduct(product);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
            {
                return BadRequest();
            }
            product.Id = new ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Created", true);
        }
    }
}
