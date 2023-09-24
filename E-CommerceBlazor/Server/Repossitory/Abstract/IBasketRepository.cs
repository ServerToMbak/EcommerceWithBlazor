using E_CommerceBlazor.Server.Model;
using StackExchange.Redis;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IBasketRepository
    {
        Task<DataResponse<Basket>> UpdateBasket(Basket basket);
        Task<DataResponse<bool>> DeleteBasketAsync(string basketId);

    }
}
