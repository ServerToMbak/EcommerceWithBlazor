using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Abstract
{
    public interface IAddressRepository
    {
        Task<DataResponse<Address>> CreateAddress(AddressDTO addressDTO);
    }
}
