using GeekShopping.Product.Api.Data.ValueObjects;
using GeekShopping.Product.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;   
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _repository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            var product = await _repository.FindById(id);

            if(product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductVO product)
        {
            if(product == null)
                return BadRequest();
            var prod = await _repository.Create(product);
            if (prod == null)
                return BadRequest();
            return Ok(prod);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductVO product)
        {
            if (product == null)
                return BadRequest();
            var prod = await _repository.Update(product);
            if (prod == null)
                return BadRequest();
            return Ok(prod);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);

            if (deleted)
                return Ok();
            else
                return BadRequest();
        }


    }
}
