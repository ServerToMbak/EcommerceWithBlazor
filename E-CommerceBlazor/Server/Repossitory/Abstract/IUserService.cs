using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IUserService
    {
        public Task<User> GetByMail(string Email);
        public Task<bool> UserExist(string Email);
    }
}
