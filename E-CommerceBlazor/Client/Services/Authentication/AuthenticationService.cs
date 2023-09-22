using E_CommerceBlazor.Client.Authentication;
using E_CommerceBlazor.Client.Pages.User;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _stateProvider;

        public AuthenticationService(HttpClient http, 
                AuthenticationStateProvider stateProvide)
        {
            _http = http;
            _stateProvider = stateProvide;
        }

        public async Task<DataResponse<string>> Login(LoginDto login)
        {
            var result = await _http.PostAsJsonAsync("https://localhost:44387/login", login);
            return await result.Content.ReadFromJsonAsync<DataResponse<string>>();
        }

        public async Task<DataResponse<string>> Register(RegisterDto register)
        {
            var result = await _http.PostAsJsonAsync("https://localhost:44387/register", register);
            return await result.Content.ReadFromJsonAsync<DataResponse<string>>();
        }
    }
}
