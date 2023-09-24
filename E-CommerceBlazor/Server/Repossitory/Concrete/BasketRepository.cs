using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Server.Repository.Abstract;
using StackExchange.Redis;
using System.Text.Json;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _db;
        public BasketRepository(IConnectionMultiplexer db)
        {
            _db = db.GetDatabase();
        }
        public async Task<DataResponse<bool>> DeleteBasketAsync(string basketId)
        {
            var delete =await _db.KeyDeleteAsync(basketId);
            if (delete == false)
            { 
                return new DataResponse<bool> {Data = false, Success = false, Message ="An error occured while deleting the basket " }; 
           
            }
            return new DataResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "The basket has deleted"
            };

        }

        public async Task<DataResponse<Basket>> UpdateBasket(Basket basket)
        {
            _db.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            var obj = await _db.StringGetAsync(basket.Id);
            var dataobj = JsonSerializer.Deserialize<Basket>(obj);
            return new DataResponse<Basket> 
            {
                Data = dataobj,
                Success = true,
                Message = "Basket is Created"
            };

        }        
    }
}
