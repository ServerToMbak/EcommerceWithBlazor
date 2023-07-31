using Server.Model;

namespace Server.Service.Abstract
{
    public interface IUserService
    {
        public Task<User> GetByMail(string Email);
        public Task<bool> UserExist(string Email);
    }
}
