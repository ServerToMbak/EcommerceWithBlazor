using Microsoft.EntityFrameworkCore;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Server.Repository.Abstract;
using System.Security.Claims;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId() 
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


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
