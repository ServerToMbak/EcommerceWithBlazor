using E_CommerceBlazor.Shared.Model;
namespace E_CommerceBlazor.Server.Repository.Abstract

{
    public interface IOrderRepository
    {
        Task<DataResponse<Order>> CreateOrder(string basketId);
        Task<DataResponse<List<Order>>> GetAllOrders();
    }
}
