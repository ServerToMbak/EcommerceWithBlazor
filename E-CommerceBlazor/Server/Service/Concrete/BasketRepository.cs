using E_CommerceBlazor.Server.Service.Abstract;
using StackExchange.Redis;

namespace E_CommerceBlazor.Server.Service.Concrete
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }
    }
}
