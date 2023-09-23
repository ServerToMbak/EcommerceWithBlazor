

using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface IProductService
    {
        Task<DataResponse<List<ProductReadDTO>>> GetAllProducts();
    }
}
