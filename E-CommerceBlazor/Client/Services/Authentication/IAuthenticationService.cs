using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Client.Authentication
{
    public interface IAuthenticationService
    {
        Task<DataResponse<string>> Login(LoginDto login);
        Task<DataResponse<string>> Register(RegisterDto register);
    }
}
