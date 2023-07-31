using Server.Dto;
using Server.Model;
using Sever.Dto;

namespace Server.Service.Abstract
{
    public interface IAuthService
    {
        public Task<DataResponse<string>> Register(RegisterDto registerDto);
        public Task<DataResponse<string>> Login(LoginDto loginDto);
    }
}
