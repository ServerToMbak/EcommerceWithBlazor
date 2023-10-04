using Blazored.LocalStorage;
using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Model;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;

        public BasketService(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorageService  = localStorageService;    
        }

        public async Task<DataResponse<int>> CountBasket(string key)
        {
            var result = await _http.GetAsync($"https://localhost:44387/api/Basket/countbasket?key={key}");
            return await result.Content.ReadFromJsonAsync<DataResponse<int>>();
        }

        public async Task<DataResponse<Basket>> CreateBasket(Basket basket)
        {
            var result = await _http.PostAsJsonAsync("https://localhost:44387/api/Basket/create",basket);
            return await result.Content.ReadFromJsonAsync<DataResponse<Basket>>();
        }

        public async Task<DataResponse<Basket>> GetBasket(string key)
        {
            var result = await _http.GetAsync($"https://localhost:44387/api/Basket?key={key}");
            return await result.Content.ReadFromJsonAsync<DataResponse<Basket>>();
        }
    }
}
