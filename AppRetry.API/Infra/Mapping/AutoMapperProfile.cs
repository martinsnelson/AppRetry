using AppRetry.API.DTO;
using AppRetry.API.Entities;
using AutoMapper;

namespace AppRetry.API.Infra.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}