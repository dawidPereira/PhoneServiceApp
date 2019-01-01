using AutoMapper;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.SaparePart;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ConstructUsing(x => new ProductResponse
                {
                    ProductId = x.ProductId,
                    Producer = x.Producer,
                    Model = x.Model,
                    Description = x.Description,
                    SapareParts = Mapper.Map<List<SaparePartResponse>>(x.ProductSapareParts)
                });

            CreateMap<ProductAddRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<ProductSearchRequest, Product>();

        }

    }
}
