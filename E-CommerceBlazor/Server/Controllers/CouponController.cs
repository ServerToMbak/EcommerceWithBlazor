using E_CommerceBlazor.Server.Repository.Abstract;
using E_CommerceBlazor.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepositıory _couponRepository;

        public CouponController(ICouponRepositıory couponRepository)
        {
            _couponRepository = couponRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddCoupon(CouponCreateDTO couponDTO)
        {
            var result = await _couponRepository.AddCoupon(couponDTO);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
        [HttpGet("allcoupons")]
        public async Task<ActionResult> GetAllCoupons( )
        {
            var result = await _couponRepository.GetAllCoupons();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCoupon(int couponId)
        {
            var result = await _couponRepository.DeleteCoupon(couponId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
