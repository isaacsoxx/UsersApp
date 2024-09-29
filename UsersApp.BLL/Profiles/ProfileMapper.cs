using AutoMapper;
using UsersApp.DAL.Entities;
using UsersApp.DTOs.Model;
using UsersApp.DTOs.Request;

namespace FitFlexApp.BLL.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserRequestDto, User>();
        }
    }
}
