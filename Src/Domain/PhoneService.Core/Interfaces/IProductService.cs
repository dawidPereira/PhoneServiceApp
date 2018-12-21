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

        Task AddCustomerAsync(ProductAddRequest customerRequest);

        Task UpdateCustomerAsync(ProductUpdateRequest customerRequest);

        Task RemoveCustomerAsync(int customerId);
    }
}
