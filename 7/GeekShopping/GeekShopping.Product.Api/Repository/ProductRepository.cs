using AutoMapper;
using GeekShopping.Product.Api.Data.ValueObjects;
using GeekShopping.Product.Api.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IMapper _mapper;
        private readonly AppDbContext _repository;
        public ProductRepository(IMapper mapper,AppDbContext repository)
        {
            _mapper=mapper;
            _repository = repository;
        }
        public async Task<ProductVO> Create(ProductVO product)
        {
            var prod = _mapper.Map<GeekShopping.ProductApi.Models.Product>(product);

            _repository.Products.Add(prod);

            await _repository.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var prod = _repository.Products.Where(x => x.Id == id).FirstOrDefault();

                if (prod == null)
                    return false;

                _repository.Products.Remove(prod);
                await _repository.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }       
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _repository.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _repository.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public Task<ProductVO> Update(ProductVO product)
        {
            var prod = _mapper.Map<GeekShopping.ProductApi.Models.Product>(product);
            _repository.Products.Update(prod);

            throw new NotImplementedException();
        }
    }
}
