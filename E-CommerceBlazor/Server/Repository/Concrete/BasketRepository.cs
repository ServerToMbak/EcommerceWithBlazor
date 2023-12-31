﻿using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Server.Repository.Abstract;
using StackExchange.Redis;
using System.Text.Json;
using AutoMapper;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IMapper _mapper;
        private readonly IDatabase _db;
        public BasketRepository(IConnectionMultiplexer db, IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<DataResponse<Basket>> GetBasketAsync(string key)
        {
            var basketJson=await _db.StringGetAsync(key);
            
            var basket = JsonSerializer.Deserialize<Basket>(basketJson);
            if(basket == null)
            {
                throw new ArgumentNullException();
            }

            return new DataResponse<Basket>
            {
                Data = basket,
                Success = true,
                Message ="basket get method is worked successfully"
            };
        }

        public async Task<DataResponse<Basket>> CreateOrUpdateBasket(Basket basket)
        {
            int counted = 0;
            foreach (var item in basket.Items) 
            {
                counted = item.TotalItemPrice + counted;
            }
            basket.TotalPrice = counted;
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

        public async Task<DataResponse<int>> NumberOfBasketItem(string key)
        {

            var basketJson = await _db.StringGetAsync(key);

            var basket = JsonSerializer.Deserialize<Basket>(basketJson);

            var count= basket.Items.Count();
            return new DataResponse<int>
            {
                Data = count,
                Success = true,
                Message ="Number of basket Item has getted"
            };
        }
    }
}
