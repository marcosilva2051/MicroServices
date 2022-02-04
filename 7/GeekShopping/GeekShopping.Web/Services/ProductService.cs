using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "api/v1/product";
        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(baseUrl);

            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/{id}");

            return await response.ReadContentAs<ProductModel>();
        }
            public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _httpClient.PostAsJson<ProductModel>(baseUrl, product);

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");

            return await response.ReadContentAs<bool>();

        }

        
        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _httpClient.PustAsJson<ProductModel>(baseUrl, product);

            return await response.ReadContentAs<ProductModel>();
        }
    }
}
