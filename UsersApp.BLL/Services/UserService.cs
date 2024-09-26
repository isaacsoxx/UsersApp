using AutoMapper;
using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DAL.Repository.Interface;
using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;

namespace FitFlexApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponseDTO<IEnumerable<UserDTO>>> GetUsersListAsync()
        {
            var serviceResponse = new ServiceResponseDTO<IEnumerable<UserDTO>>();
            var usersList = await _repository.GetUsersListAsync();
            serviceResponse.Data = _mapper.Map<IEnumerable<UserDTO>>(usersList);
            return serviceResponse;
        }

        public async Task<ServiceResponseDTO<UserIncludePlanDTO>> GetUserByIdIncludePlanAsync(int userId)
        {
            var serviceResponse = new ServiceResponseDTO<UserIncludePlanDTO>();
            var user = await _repository.GetSingleUserIncludeTrainingPlansAsync(userId);

            if (user != null)
            {
                serviceResponse.Data = _mapper.Map<UserIncludePlanDTO>(user);
            }
            else
            {
                serviceResponse.Message = $"User with id {userId} was not found!";
                serviceResponse.Error = true;
                serviceResponse.StatusCode = 404;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseDTO<bool>> CreateSingleUserAsync(UserRequestDto user)
        {
            var serviceResponse = new ServiceResponseDTO<bool>();
            var userToCreate = _mapper.Map<User>(user);
            serviceResponse.Data = await _repository.CreateSingleUserAsync(userToCreate);
            return serviceResponse;
        }

        public async Task<ServiceResponseDTO<bool>> UpdateSingleUserAsync(UserRequestDto user)
        {
            var serviceResponse = new ServiceResponseDTO<bool>();
            var userToUpdate = await _repository.GetSingleUserIncludeTrainingPlansAsync(user.UserId);

            if (userToUpdate != null)
            {
                _mapper.Map(user, userToUpdate);
                serviceResponse.Data = await _repository.UpdateSingleUserAsync(_mapper.Map(user, userToUpdate));
            }

            return serviceResponse;
        }
    }
}
