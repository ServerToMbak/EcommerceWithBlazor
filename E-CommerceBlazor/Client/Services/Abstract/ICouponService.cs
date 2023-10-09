using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface ICouponService
    {
        Task<DataResponse<List<Coupon>>> GetAllCoupons();
        Task<Response> Delete(int couponId);
        Task<DataResponse<Coupon>> AddCoupon(CouponCreateDTO couponDTO);
    }
}
