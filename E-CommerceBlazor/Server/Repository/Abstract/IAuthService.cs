using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IAuthService
    {
        public Task<DataResponse<string>> Register(RegisterDto registerDto);
        public Task<DataResponse<string>> Login(LoginDto loginDto);
    }
}
