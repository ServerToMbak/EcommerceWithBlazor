using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using Server.Model;
using Server.Service.Abstract;

namespace Server.Controllers
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
       [HttpGet("/getall")]
       public async Task<ActionResult<List<ProductReadDto>>> GetAll() 
       {
           var result =await _repo.GetAll();
            var readDto = _mapper.Map<List<ProductReadDto>>(result.Data);
            
            
              return Ok(readDto);
      
       }
       [HttpPost("/add")]
       public async Task<ActionResult<Response>> Add(ProductCreateDto productDto)
       {
            var product = _mapper.Map<Product>(productDto);
            var response = await _repo.Add(product);
            return Ok(response);
       } 
    }
}
