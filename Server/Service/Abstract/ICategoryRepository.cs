using Server.Model;

namespace Server.Service.Abstract
{
    public interface ICategoryRepository
    {
        public Task<Response> Add(Category category);
        public Task<Response> Delete(int categoryId);
        public Task<DataResponse<Category>> GetById(int categoryId);
        public Task<DataResponse<List<Category>>> GetAll();
    }
}
