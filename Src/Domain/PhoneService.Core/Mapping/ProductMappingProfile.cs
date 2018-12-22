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
                .ForMember(x => x.SapareParts, m => m.MapFrom(src => src.ProductSapareParts));
            CreateMap<ProductAddRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<ProductSearchRequest, Product>();
        }

    }
}
