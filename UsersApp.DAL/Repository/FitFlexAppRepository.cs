using Microsoft.EntityFrameworkCore;
using UsersApp.DAL.Context;
using UsersApp.DAL.Entities;
using UsersApp.DAL.Repository.Interface;

namespace UsersApp.DAL.Repository
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
        public async Task<User?> GetSingleUserAsync(int userId)
        {
            return await _context.Users.Where(u => u.UserId.Equals(userId)).FirstOrDefaultAsync();
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
            var user = await _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();

            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            return null;
        }
    }
}
