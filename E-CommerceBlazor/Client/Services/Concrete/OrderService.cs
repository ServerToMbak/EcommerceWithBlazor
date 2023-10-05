using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Model;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class OrderService: IOrderService
    {
        private readonly HttpClient _http;

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<DataResponse<List<Order>>> GetAllOrdersByUser()
        {
            return await _http.GetFromJsonAsync<DataResponse<List<Order>>>
                    ("https://localhost:44387/api/Order"); 
        }
        public async Task<DataResponse<List<Order>>> GetAllOrders()
        {
            return await _http.GetFromJsonAsync<DataResponse<List<Order>>>
                    ("https://localhost:44387/api/Order/admin");
        }
    }
}
