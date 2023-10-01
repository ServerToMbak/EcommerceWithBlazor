using E_CommerceBlazor.Client.Pages.Payment;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface IAddressService
    {
        Task<DataResponse<Address>> CreateAddress(AddressDTO addressDTO);
        Task<DataResponse<AddressDTO>> GetAddress();
    }
}
