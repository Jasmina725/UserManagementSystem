using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Abstraction
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task DeleteUser(User id);
        Task<bool> SaveChanges();
    }
}
