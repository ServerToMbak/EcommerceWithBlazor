using AutoMapper;
using Server.Dto;
using Server.Model;

namespace Server.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<RegisterDto,User>();
            CreateMap<ProductCreateDto, Product>();
            
            CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
