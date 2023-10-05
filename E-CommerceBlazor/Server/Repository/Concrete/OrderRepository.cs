using AutoMapper;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Repository.Abstract;
using E_CommerceBlazor.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private IUserService _userService;
        private IBasketRepository _basketRepository;

        public OrderRepository(ApplicationDbContext context,IMapper mapper, IUserService userService,
            IBasketRepository basketRepository)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _basketRepository = basketRepository;
        }

        public async Task<DataResponse<Shared.Model.Order>> CreateOrder(string basketId)
        {
            var basket =(await _basketRepository.GetBasketAsync(basketId)).Data;

            if (basket == null) { return new DataResponse<Order> { Data = null, Message = "basket is empty", Success = false }; }
           
            Order order = new Order();
            order.SubTotal = basket.TotalPrice;
            order.UserId = _userService.GetUserId();

            await _context.Orders.AddAsync(order);

            List<OrderItem> listOfOrder = new List<OrderItem>();
           foreach(var item in basket.Items)
           {
                OrderItem orderItem = new OrderItem
                {
                    Name = item.Name,
                    ProductId = Convert.ToInt32(item.Id),
                    PictureUrl = item.PictureUrl,
                    Price = item.TotalItemPrice,
                    ProductItemPrice = Convert.ToDouble(item.Price),
                    Quantity = item.Quantity,
                    OrderId = order.Id
                };
                listOfOrder.Add( orderItem);
           }


            order.OrderItems = listOfOrder;
            await _context.SaveChangesAsync();
            if (order == null)
            {
              throw new ArgumentNullException(nameof(order));   
            }

            await _basketRepository.DeleteBasketAsync(basketId);

            
            return new DataResponse<Order>
            {
                Data = order,
                Message = "order has added",
                Success = true
            };
        }

        public async Task<DataResponse<List<Order>>> GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            
            if(orders == null)
            {
                return new DataResponse<List<Order>> 
                {
                    Data = null, Success = false, Message = "There is no order to see yet!"
                };
            }
            return new DataResponse<List<Order>>
            {
                Data = orders,
                Success = false,
                Message = " All Orders getted"
            };
        }

        public async Task<DataResponse<List<Shared.Model.Order>>> GetAllOrdersByUser()
        {
            var userId = _userService.GetUserId();
            var orders = await _context.Orders.Where(opt => opt.UserId == userId).Include(opt => opt.OrderItems).ToListAsync();
        
            if(orders == null)
            {
                return new DataResponse<List<Order>>
                {
                    Data = null, Message = " User does not have any order from past",Success = false
                };
            }
            return new DataResponse<List<Order>> 
            { Data = orders, Message = "All old orders getted successfully"  };
        
        
        }
    }
}
