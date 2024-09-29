
using UsersApp.DAL.Entities;

namespace UsersApp.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersListAsync();
        Task<User?> GetSingleUserAsync(int userId);
        Task<bool> CreateSingleUserAsync(User user);
        Task<bool> UpdateSingleUserAsync(User user);
        Task<User?> ValidateUserAsync(string username, string password);
    }
}
