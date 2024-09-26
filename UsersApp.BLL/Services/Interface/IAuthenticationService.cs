using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;

namespace FitFlexApp.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<ServiceResponseDTO<UserDTO>> ValidateCredentials(string username, string password);
    }
}
