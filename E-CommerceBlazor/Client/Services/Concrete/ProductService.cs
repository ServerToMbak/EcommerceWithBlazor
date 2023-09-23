﻿using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<DataResponse<List<ProductReadDTO>>> GetAllProducts()
        {
            var result =await _http.GetAsync("https://localhost:44387/api/Products/getall");
            return await result.Content.ReadFromJsonAsync<DataResponse<List<ProductReadDTO>>>();
        }
    }
}
