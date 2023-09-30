using AutoMapper;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Repository.Abstract;
using E_CommerceBlazor.Server.Repossitory.Abstract;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Concrete
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AddressRepository(ApplicationDbContext context, 
            IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<DataResponse<Address>> CreateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            address.UserId = _userService.GetUserId();
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            if(address == null)
            {
                return new DataResponse<Address>
                {
                    Data = null,
                    Message = "An error occured while adding your address try again",
                    Success = false
                };
            }
            return new DataResponse<Address>
            {
                Data = address,
                Message = "Your Address is saved",
                Success = true
            };
        
        }
    }
}
