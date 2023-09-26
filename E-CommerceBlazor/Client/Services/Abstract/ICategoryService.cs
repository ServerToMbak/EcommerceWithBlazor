using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface ICategoryService
    {
        Task<DataResponse<List<CategoryDto>>> GetAllCategorries();
        Task<DataResponse<CategoryDto>> GetByCategoryId(int id);
    }
}
