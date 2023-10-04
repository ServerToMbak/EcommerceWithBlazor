using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface IOrderService
    {
        Task<DataResponse<List<Order>>> GetAllOrders();
    }
}
