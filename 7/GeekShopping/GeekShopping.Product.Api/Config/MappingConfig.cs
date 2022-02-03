using AutoMapper;
using GeekShopping.Product.Api.Data.ValueObjects;
namespace GeekShopping.Product.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, GeekShopping.ProductApi.Models.Product>();
                config.CreateMap<GeekShopping.ProductApi.Models.Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
