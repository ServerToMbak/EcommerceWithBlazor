using E_CommerceBlazor.Server.Repossitory.Abstract;
using E_CommerceBlazor.Shared.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using StackExchange.Redis;
using Iyzipay;
using Iyzipay.Request;
using Iyzipay.Model;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace E_CommerceBlazor.Server.Repossitory.Concrete
{
    public class PaymentService : IPaymentService
    {
        IDatabase _db;
        private readonly IConfiguration _config;

        public PaymentService(IConnectionMultiplexer db, IConfiguration config)
        {
            _db = db.GetDatabase();
            _config = config;
        }
        public async Task<Response> CreatePaymentRequest(string basketId, Iyzipay.Model.PaymentCard card)
        {
            var basketJson =await _db.StringGetAsync(basketId);
            var basket = JsonSerializer.Deserialize<Basket>(basketJson);
        
            if(basket == null)
            {
                throw new ArgumentNullException(nameof(basket));   
            }
           Options options = new Options();
            options.ApiKey = _config["iyzipay:ApiKey"];
            options.SecretKey = _config["iyzipay:SecretKey"];
            options.BaseUrl = _config["iyzipay:BaseUrl"];



            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Currency = Currency.TRY.ToString();
            request.PaidPrice = Convert.ToString(basket.TotalPrice + (basket.TotalPrice*0.2));
            request.Price = Convert.ToString(basket.TotalPrice);
            request.BasketId = basketId;
            request.PaymentChannel = PaymentChannel.WEB.ToString();

            request.PaymentCard = card;

            Iyzipay.Model.Address address = new Iyzipay.Model.Address();

            

            Buyer buyer = new Buyer();
            buyer.Id = "SA";
            buyer.Name = "server";
            buyer.Surname = "Tombak";
            buyer.Email = "server71835@gmail.com";
            buyer.IdentityNumber = "12345";
            buyer.RegistrationAddress = "address";
            buyer.City = "sad";
            buyer.Country = "asd";
            buyer.ZipCode = "123456";
            
            request.Buyer = buyer;

            Iyzipay.Model.Address billingAddress = new Iyzipay.Model.Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";

            List<Iyzipay.Model.BasketItem> basIt = new List<Iyzipay.Model.BasketItem>();

            List<Shared.Model.BasketItem> itemList = basket.Items;

            foreach(var Item in itemList)
            {
                Iyzipay.Model.BasketItem itemofpayment = new Iyzipay.Model.BasketItem();
                
                Item.Name = itemofpayment.Name;

                basIt.Add(itemofpayment);
            }

            request.BasketItems = null;
            request.BillingAddress = billingAddress;
            request.BasketItems = basIt;
            Payment payment = Payment.Create(request, options);
            return new Response 
            {
                Message = "Payment has done",
                Success = true
            };

        }
    }
}
