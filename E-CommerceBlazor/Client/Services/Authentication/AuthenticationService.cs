using Microsoft.AspNetCore.Components.Authorization;

namespace E_Commerce.Services.Authentication
{
    public class AuthenticationService :IAuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _stateProvider;

        public AuthenticationService(HttpClient http, 
                AuthenticationStateProvider stateProvide)
        {
            _http = http;
            _stateProvider = stateProvide;
        }
    }
}
