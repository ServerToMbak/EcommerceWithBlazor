using Microsoft.AspNetCore.Mvc;
using Server.Service.Abstract;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
       [HttpGet]
       public IActionResult Index() 
       {
            return Ok("sD"); 
       }
    }
}
