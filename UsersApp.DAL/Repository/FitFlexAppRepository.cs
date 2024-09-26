using FitFlexApp.DAL.Context;
using FitFlexApp.DAL.Entities;
using FitFlexApp.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitFlexApp.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FitFlexAppContext _context;
        public UserRepository(FitFlexAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> GetUsersListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetSingleUserIncludeTrainingPlansAsync(int userId)
        {
            return await _context.Users.Include(u => u.TrainingPlans).Where(u => u.UserId.Equals(userId)).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateSingleUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSingleUserAsync(User user)
        {
            _context.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users.Where(u => u.Email.Equals(email)).Include(u => u.AccessLevel).FirstOrDefaultAsync();

            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            return null;
        }
    }
}
