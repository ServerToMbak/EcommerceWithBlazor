using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface ICouponRepositıory
    {
        Task<DataResponse<Coupon>> AddCoupon(CouponCreateDTO couponDTO);
        Task<DataResponse<List<Coupon>>> GetAllCoupons();
        Task<Response> DeleteCoupon(int couponId);

    }
}
