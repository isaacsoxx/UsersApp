using AutoMapper;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;

namespace FitFlexApp.BLL.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserIncludePlanDTO>();
            CreateMap<UserIncludePlanDTO, User>();
            CreateMap<UserRequestDto, User>();

            CreateMap<AccessLevel, AccessLevelDTO>();
            CreateMap<AccessLevelDTO, AccessLevel>();

            CreateMap<TrainingPlan, TrainingPlanDTO>();
            CreateMap<TrainingPlanDTO, TrainingPlan>();

            CreateMap<TrainingPlanType, TrainingPlanTypeDTO>();
            CreateMap<TrainingPlanTypeDTO, TrainingPlanType>();
        }
    }
}
