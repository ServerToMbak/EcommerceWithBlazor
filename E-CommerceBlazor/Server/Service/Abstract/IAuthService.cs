using E_CommerceBlazor.Server.Dto;
using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Server.Dto;

namespace E_CommerceBlazor.Server.Service.Abstract
{
    public interface IAuthService
    {
        public Task<DataResponse<string>> Register(RegisterDto registerDto);
        public Task<DataResponse<string>> Login(LoginDto loginDto);
    }
}
