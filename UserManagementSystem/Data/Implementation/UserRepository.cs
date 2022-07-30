using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Abstraction;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        UserManagementContext _context;

        public UserRepository(UserManagementContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await SaveChanges();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Equals(id));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
