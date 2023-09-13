using Assignment1.DataContextModels;
using Assignment1.DTOs;
using AutoMapper;

namespace Assignment1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<UserDto, User>();
        }
    }
}
