using Microsoft.AspNetCore.Mvc;
using PetShop.BL.Interfaces;
using PetShop.Models.Models;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]

        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]

        public ActionResult<Product> Add(Product product)
        {
            _productService.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return NoContent();
        }
    }
}
