using FitFlexApp.DAL.Entities;

namespace FitFlexApp.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersListAsync();
        Task<User?> GetSingleUserIncludeTrainingPlansAsync(int userId);
        Task<bool> CreateSingleUserAsync(User user);
        Task<bool> UpdateSingleUserAsync(User user);
        Task<User?> ValidateUserAsync(string username, string password);
    }
}
