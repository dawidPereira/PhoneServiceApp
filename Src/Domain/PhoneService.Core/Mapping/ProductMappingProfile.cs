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
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductAddRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();

        }

    }
}
