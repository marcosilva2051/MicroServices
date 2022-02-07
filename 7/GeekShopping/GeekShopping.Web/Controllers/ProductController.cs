using GeekShopping.Web.Models;
using GeekShopping.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService  _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {

            if (ModelState.IsValid)
            {
                var productCreated = await _productService.CreateProduct(product);

                if (productCreated != null)
                    return RedirectToAction(nameof(ProductIndex));
            }         
            return View(product);
        }

        public async Task<IActionResult> ProductCreate()
        { 
            return View();
        }

        
        public async Task<IActionResult> ProductUpdate(int Id)
        {

                var productCreated = await _productService.FindProductById(Id);

                if (productCreated != null)
                    return View(productCreated);
                else
                    return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var productCreated = await _productService.UpdateProduct(productModel);

                if (productCreated != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View();
        }

        public async Task<IActionResult> ProductDelete(int id)
        {

            var product = await _productService.FindProductById(id);

            if (product != null)
                return View(product);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel product)
        {

            var deleted = await _productService.DeleteProduct(product.Id);

            if (deleted)
                return RedirectToAction(nameof(ProductIndex));
            else
                return View(product);
        }

        //public async Task<IActionResult> ProductUpdate()
        //{
        //    return View();
        //}
    }
}
