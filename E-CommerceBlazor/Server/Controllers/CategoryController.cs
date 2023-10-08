using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Server.Repository.Abstract;

namespace E_CommerceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repo = categoryRepository;
           _mapper =mapper;
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
            var response = await _repo.GetById(categoryId);
         
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Response>> Add(CategoryCreateDTO categoryCreateDto)
        {
            var response =await _repo.Add(categoryCreateDto);

           return Ok(response); 
        }
        [HttpDelete("delete")] 
        public async Task<ActionResult<Response>> Delete(int categoryId)
        {
            var result = await _repo.DeleteCategory(categoryId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
