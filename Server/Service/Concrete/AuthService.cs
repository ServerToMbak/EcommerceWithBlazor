using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Dto;
using Server.Model;
using Server.Service.Abstract;
using Sever.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Server.Service.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext context,
                IConfiguration config,
                IUserService userService,
                IMapper mapper)
        {
            _context = context;
            _config = config;
            _userService = userService;
            _mapper  = mapper;  
        }
        public async Task<DataResponse<string>> Login(LoginDto loginDto)
        {
           var user =await _userService.GetByMail(loginDto.Email);
            if (user == null) 
            {
                return new DataResponse<string>
                {
                    Message = "User does not exist",
                    Success = false,
                    Data = null
                };
            }
            else if(!VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new DataResponse<string>
                {
                    Message = "Check your Password",
                    Data = null,
                    Success = false
                };
            }
            else
            {
                var token = CreateToken(user);
                return new DataResponse<string>
                {
                    Data = token.Data,
                    Success = true,
                    Message ="You have logged in"

                };
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, 
                out byte[] passwordSalt )
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<DataResponse<string>> Register(RegisterDto registerDto)
        {
            var response =await _userService.UserExist(registerDto.Email);
            var user = _mapper.Map<User>(registerDto);
            if(response)
            {
                return new DataResponse<string>
                {
                    Data = null,
                    Message = "User is already Exists",
                    Success = false,
                };
            }
            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.DateCreated = DateTime.Now;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var token = CreateToken(user);

            return new DataResponse<string>
            {
                Data = token.Data,
                Message = "User has registered Suuccessfuly",
                Success = true,
            };
        }
        public DataResponse<string> CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:SecretKey").Value));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                    claims :claims,
                    signingCredentials : credentials,
                    expires: DateTime.Now.AddDays(1)    
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new DataResponse<string>
            {
                Data = jwt,
                Message="Token Created Succesfuly",
                Success = true
            };
        }
    }
}
