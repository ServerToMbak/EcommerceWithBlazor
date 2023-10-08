using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Response> AddCategory(CategoryCreateDTO categoryDTO)
        {
            var resut = await _http.PostAsJsonAsync("https://localhost:44387/api/Category/add", categoryDTO);
            return await resut.Content.ReadFromJsonAsync<Response>();
        }

        public async Task<Response> DeleteCategory(int categoryId)
        {
            var result = await _http.DeleteAsync($"https://localhost:44387/api/Category/?={categoryId}");
            return await result.Content.ReadFromJsonAsync<Response>();
        }

        public async Task<DataResponse<List<CategoryDto>>> GetAllCategorries()
        {
            var result =await _http.GetAsync("https://localhost:44387/api/Category/getallcategories");
            return await result.Content.ReadFromJsonAsync<DataResponse<List<CategoryDto>>>();
        }
        
        public async Task<DataResponse<CategoryDto>> GetByCategoryId(int id)
        {
            var result = await _http.GetAsync($"https://localhost:44387/api/Category/{id}");
            return await result.Content.ReadFromJsonAsync<DataResponse<CategoryDto>>();
        }
    }
}
