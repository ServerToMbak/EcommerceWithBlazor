using AutoMapper;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Repository.Abstract;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class CouponRepository : ICouponRepositıory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(ApplicationDbContext context, IMapper mapper)
        { 
            _context =context;
            _mapper = mapper;
        }
        public async Task<DataResponse<Coupon>> AddCoupon(CouponCreateDTO couponDTO)
        {
           var coupon = _mapper.Map<Coupon>(couponDTO);
            if(coupon == null)
            {
                return new DataResponse<Coupon>
                {
                    Data =  null,
                    Message ="Kupon oluşturulurken bir sorunla karşılaşıldı",
                    Success = false
                };
            }
           await _context.Coupons.AddAsync(coupon);
           await _context.SaveChangesAsync();
            return new DataResponse<Coupon>
            {
                Data = coupon,
                Message = "Kupon oluşturuldu",
                Success = true
            };
        }

        public async Task<Response> DeleteCoupon(int couponId)
        {
            var coupon = await _context.Coupons.Where(opt => opt.Id == couponId).FirstOrDefaultAsync();
            if(coupon == null)
            {
                return new Response
                {
                    Message = " Kupon bulunamadı",
                    Success = false
                };
            }
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync() ;
            return new Response
            {
                Success = true, Message = "Kupon silindi" 
            
            };
        }

        public async Task<DataResponse<List<Coupon>>> GetAllCoupons()
        {
            var coupons = await _context.Coupons.ToListAsync();
            if(coupons == null)
            {
                return new DataResponse<List<Coupon>>
                {
                    Data = coupons,
                    Message = "Hiç kupon bulunmamaktadır",
                    Success  = true
                };
            }
            return new DataResponse<List<Coupon>>
            {
                Data = coupons,
                Message = "Kuponlar getirildi",
                Success = true
            };
        }
    }
}
