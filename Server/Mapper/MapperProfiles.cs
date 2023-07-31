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
        }
    }
}
