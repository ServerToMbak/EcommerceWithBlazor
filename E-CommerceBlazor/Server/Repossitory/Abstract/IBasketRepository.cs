using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IBasketRepository
    {
        Task<DataResponse<Basket>> UpdateBasket(Basket baske);
        Task<DataResponse<bool>> DeleteBasketAsync(string basketId);
        Task<DataResponse<Basket>> GetBasketAsync(string key);

    }
}
