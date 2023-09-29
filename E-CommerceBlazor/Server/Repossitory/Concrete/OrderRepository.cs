using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Repossitory.Abstract;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<DataResponse<Order>> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteOrder(int orderIr)
        {
            throw new NotImplementedException();
        }
    }
}
