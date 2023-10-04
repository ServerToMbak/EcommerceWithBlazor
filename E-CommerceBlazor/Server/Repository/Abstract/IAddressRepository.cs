using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IAddressRepository
    {
        Task<DataResponse<Address>> CreateAddress(AddressDTO addressDTO);
        Task<DataResponse<AddressDTO>> GetAddress();
    }
}
