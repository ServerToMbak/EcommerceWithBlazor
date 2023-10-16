using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Server.Repository.Abstract;

namespace E_CommerceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController :ControllerBase
    {
       private readonly IProductRepository _repo;
       private readonly IMapper _mapper;

       public ProductsController(IProductRepository repo, IMapper mapper)
       {
            _repo = repo;
            _mapper = mapper;
       }
       [HttpGet("getall")]
       public async Task<ActionResult<List<ProductReadDTO>>> GetAll() 
       {
           var result =await _repo.GetAll();
           return Ok(result);
      
       }
       [HttpPost("add")]
       public async Task<ActionResult<Response>> Add(ProductCreateDto productDto)
       {
            var product = _mapper.Map<Product>(productDto);
            var response = await _repo.Add(product);
            return Ok(response);
       }
       [HttpGet("getbyid")]
       public async Task<ActionResult> GetProductReadDtoByProductId(int ProductId)
        {
            var product =await _repo.GetById(ProductId);
            if(product == null)
            {
                return BadRequest();
            }
            return Ok(product); 
        }
    }
}
