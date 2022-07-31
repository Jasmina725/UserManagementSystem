using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Common;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Abstraction
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(PageItem page, FilterItem filter, OrderItem order);
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task DeleteUser(User id);
        Task<bool> SaveChanges();
    }
}
