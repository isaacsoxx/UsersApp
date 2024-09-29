using AutoMapper;
using UsersApp.BLL.Services.Interface;
using UsersApp.DAL.Entities;
using UsersApp.DAL.Repository.Interface;
using UsersApp.DTOs.Model;
using UsersApp.DTOs.Request;

namespace UsersApp.BLL.Services
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

        public async Task<ServiceResponseDTO<UserDTO>> GetUserByIdAsync(int userId)
        {
            var serviceResponse = new ServiceResponseDTO<UserDTO>();
            var user = await _repository.GetSingleUserAsync(userId);

            if (user != null)
            {
                serviceResponse.Data = _mapper.Map<UserDTO>(user);
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
            var userToUpdate = await _repository.GetSingleUserAsync(user.UserId);

            if (userToUpdate != null)
            {
                _mapper.Map(user, userToUpdate);
                serviceResponse.Data = await _repository.UpdateSingleUserAsync(_mapper.Map(user, userToUpdate));
            }

            return serviceResponse;
        }
    }
}
