using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Model;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _http;

        public PaymentService(HttpClient http)
        {
            _http = http;
        }
        public async Task<Response> MakeThePayment(string basketId, PaymentCard card)
        {
            var result = await _http.PostAsJsonAsync($"https://localhost:44387/api/Payment?basketId={basketId}", card);
            return await result.Content.ReadFromJsonAsync<Response>();
        }
    }
}
