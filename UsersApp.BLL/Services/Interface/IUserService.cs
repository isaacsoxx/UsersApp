using FitFlexApp.DTOs.Model;
using FitFlexApp.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.BLL.Services.Interface
{
    public interface IUserService
    {
        Task<ServiceResponseDTO<IEnumerable<UserDTO>>> GetUsersListAsync();
        Task<ServiceResponseDTO<UserIncludePlanDTO>> GetUserByIdIncludePlanAsync(int userId);
        Task<ServiceResponseDTO<bool>> CreateSingleUserAsync(UserRequestDto user);
        Task<ServiceResponseDTO<bool>> UpdateSingleUserAsync(UserRequestDto user);
    }
}
