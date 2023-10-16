using AutoMapper;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Service.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //Source --> Destination

            CreateMap<RegisterDto,User>();
            CreateMap<ProductCreateDto, Product>();
            
            CreateMap<Product, ProductReadDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<AddressDTO,Address>().ReverseMap();
            CreateMap<PaymentCard, Iyzipay.Model.PaymentCard>().ReverseMap();
            CreateMap<CouponCreateDTO, Coupon>();
        }

    }
}
