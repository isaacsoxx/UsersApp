using UsersApp.DTOs.Model;

namespace UsersApp.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<ServiceResponseDTO<string>> ValidateCredentials(string username, string password);
    }
}
