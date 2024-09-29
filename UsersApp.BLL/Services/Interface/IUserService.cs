using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.DTOs.Model;
using UsersApp.DTOs.Request;

namespace UsersApp.BLL.Services.Interface
{
    public interface IUserService
    {
        Task<ServiceResponseDTO<IEnumerable<UserDTO>>> GetUsersListAsync();
        Task<ServiceResponseDTO<UserDTO>> GetUserByIdAsync(int userId);
        Task<ServiceResponseDTO<bool>> CreateSingleUserAsync(UserRequestDto user);
        Task<ServiceResponseDTO<bool>> UpdateSingleUserAsync(UserRequestDto user);
    }
}
