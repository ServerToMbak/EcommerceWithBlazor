using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface ICategoryRepository
    {
        public Task<Response> Add(CategoryCreateDTO categoryCreateDTO);
        public Task<Response> Delete(int categoryId);
        public Task<DataResponse<CategoryDto>> GetById(int categoryId);
        public Task<DataResponse<List<Category>>> GetAll();
    }
}
