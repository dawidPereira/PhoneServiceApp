using PhoneService.Core.Models.Product;
using PhoneService.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneService.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductAsync();

        Task<ProductResponse> GetProductByIdAsync(int productId);

        Task<IEnumerable<ProductResponse>> GetCustomerBySearchTermsAsync(ProductSearchRequest searchRequest);

        Task AddProductAsync(ProductAddRequest customerRequest);

        Task UpdateProductAsync(ProductUpdateRequest customerRequest);

        Task RemoveProductAsync(int customerId);
    }
}
