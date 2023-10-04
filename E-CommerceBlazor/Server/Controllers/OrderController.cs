using E_CommerceBlazor.Server.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBlazor.Server.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class OrderController :ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBasket(string  basketId)
        {
            var result =await _orderRepository.CreateOrder(basketId);

            if (result == null) 
            {
                return BadRequest(); ;
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrdersByUser()
        {
            var result = await _orderRepository.GetAllOrders();

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
