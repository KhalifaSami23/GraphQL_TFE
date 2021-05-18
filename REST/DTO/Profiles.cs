using AutoMapper;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.REST.DTO
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}