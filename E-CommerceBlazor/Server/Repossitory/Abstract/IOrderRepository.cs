using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Abstract
{
    public interface IOrderRepository
    {
        Task<DataResponse<Order>> CreateOrder(Order order);
        Task<Response> DeleteOrder(int orderIr);
    }
}
