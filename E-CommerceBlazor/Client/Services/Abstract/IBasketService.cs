using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface IBasketService
    {
        Task<DataResponse<Basket>> CreateBasket(Basket basket);
        Task<DataResponse<Basket>> GetBasket(string key);
        Task<DataResponse<int>> CountBasket(string key);
    }
}
