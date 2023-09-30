using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Abstract
{
    public interface IAddressRepository
    {
        Task<DataResponse<Address>> CreateAddress(Address address);
    }
}
