using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using Server.Model;
using Server.Service.Abstract;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _repo = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("getallcategories")]
        public async Task<ActionResult<DataResponse<List<CategoryDto>>>> GetAll()
        {
            var categories = await _repo.GetAll();
            var data = _mapper.Map<List<CategoryDto>>(categories.Data);
            var response = new DataResponse<List<CategoryDto>>
            {
                Data = data,
                Message = "CategoryDto List getted",
                Success = true
            };
            return Ok(response);
        
        }
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<DataResponse<CategoryDto>>> GetCategoryById(int categoryId)
        {
            var category = await _repo.GetById(categoryId);
            var data = _mapper.Map<CategoryDto>(category.Data);
            var response = new DataResponse<CategoryDto> 
            {
                Data = data,
                Message = "Category getted",
                Success = true
            };
            return Ok(response);
        }
        [HttpPost("add")]
        public async Task<Response> Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
             return await _repo.Add(category); 
        }
        //[HttpPut("delete")]sq
        //public async Task<Response> Delete(int categoryId)
        //{
        //    var category =await _repo.GetById(categoryId);
        //    var response = await _repo.Delete(category);
        //    return Ok(response); 
           
        //}
    }
}
