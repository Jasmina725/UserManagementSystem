using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserManagementSystem.Common;
using UserManagementSystem.Data.Abstraction;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementContext _context;

        public UserRepository(UserManagementContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            return (await _context.Users.AddAsync(user)).Entity;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await SaveChanges();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task<IEnumerable<User>> GetUsers(PageItem page, FilterItem filter, OrderItem order)
        {
            return await GetFiltered(_context.Users, filter).GetOrdered(order).GetPaged(page).ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        private IQueryable<User> GetFiltered(IQueryable<User> users, FilterItem filter)
        {
            if (filter == null) 
                return users;

            return users.Where(ui => (ui.FirstName.Contains(filter.FirstName) || string.IsNullOrEmpty(filter.FirstName)) &&
                        (ui.LastName.Contains(filter.LastName) || string.IsNullOrEmpty(filter.LastName)) &&
                        (ui.UserName.Contains(filter.UserName) || string.IsNullOrEmpty(filter.UserName)) &&
                        (ui.Email.Contains(filter.Email) || string.IsNullOrEmpty(filter.Email)));
        }
      
    }
}
