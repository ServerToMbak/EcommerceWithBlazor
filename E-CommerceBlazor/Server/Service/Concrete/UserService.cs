using Microsoft.EntityFrameworkCore;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Server.Service.Abstract;

namespace E_CommerceBlazor.Server.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByMail(string Email)
        {
            var user =await _context.Users.Where(O => O.Email == Email).FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> UserExist(string Email)
        {   
            var response =await _context.Users.AnyAsync(O => O.Email == Email);

            if(response)
            {
                return true;
            }
            return false;
        }
    }
}
