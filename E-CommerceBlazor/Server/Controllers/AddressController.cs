using AutoMapper;
using E_CommerceBlazor.Server.Repossitory.Abstract;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddressController: ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            var result = await _addressRepository.CreateAddress(address);
            if(result.Success == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
