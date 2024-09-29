using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;
using UsersApp.DTOs.Model;

namespace UsersApp.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<ServiceResponseDTO<UserDTO>> ValidateCredentials(string username, string password);
    }
}
