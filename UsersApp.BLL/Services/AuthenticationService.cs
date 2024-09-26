using AutoMapper;
using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.DAL.Repository.Interface;
using FitFlexApp.DTOs.Model;

namespace FitFlexApp.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponseDTO<UserDTO>> ValidateCredentials(string emailAddress, string password)
        {
            var serviceResponse = new ServiceResponseDTO<UserDTO>();
            var authenticatedUser = await _repository.ValidateUserAsync(emailAddress, password);

            if (authenticatedUser != null)
            {
                serviceResponse.Data = _mapper.Map<UserDTO>(authenticatedUser);
            } else
            {
                serviceResponse.Error = true;
                serviceResponse.Message = $"Account {emailAddress} couldn't be authenticated!";
            }

            return serviceResponse;
        }

    }
}
