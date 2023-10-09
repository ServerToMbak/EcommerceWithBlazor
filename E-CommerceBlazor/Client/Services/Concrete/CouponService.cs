using E_CommerceBlazor.Client.Services.Abstract;
using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;
using System.Net.Http.Json;

namespace E_CommerceBlazor.Client.Services.Concrete
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _http;

        public CouponService(HttpClient http)
        {
            _http = http;
        }
        public async Task<DataResponse<Coupon>> AddCoupon(CouponCreateDTO couponDTO)
        {
            var result =await _http.PostAsJsonAsync("https://localhost:44387/api/Coupon", couponDTO);  
            return await result.Content.ReadFromJsonAsync<DataResponse<Coupon>>();
        }

        public async Task<Response> Delete(int cauponId)
        {
            var result = await _http.DeleteAsync($"https://localhost:44387/api/Coupon?couponId={cauponId}");
            return await result.Content.ReadFromJsonAsync<Response>();
        }

        public async Task<DataResponse<List<Coupon>>> GetAllCoupons()
        {
            var result = await _http.GetAsync("https://localhost:44387/api/Coupon/allcoupons");
            return await result.Content.ReadFromJsonAsync<DataResponse<List<Coupon>>>();
        }
    }
}
