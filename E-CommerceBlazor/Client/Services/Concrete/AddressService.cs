using E_CommerceBlazor.Client.Pages.Payment;
using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class AddressService : IAddressService
    {
        private HttpClient _http;

        public AddressService(HttpClient http)
        {
            _http = http;
        }

        public async Task<DataResponse<Address>> CreateAddress(AddressDTO addressDTO)
        {
           var result = await _http.PostAsJsonAsync("https://localhost:44387/api/Address", addressDTO);
            return await result.Content.ReadFromJsonAsync<DataResponse<Address>>();
        }

        public async Task<DataResponse<AddressDTO>> GetAddress()
        {
            var result =await _http.GetAsync("https://localhost:44387/api/Address");
            return await result.Content.ReadFromJsonAsync<DataResponse<AddressDTO>>();
        }
    }
}
