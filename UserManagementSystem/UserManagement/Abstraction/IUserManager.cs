using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Common;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.UserManagement.Abstraction
{
    public interface IUserManager
    {
        Task<IEnumerable<UserReadDto>> GetUsers(PageItem page, FilterItem filter, OrderItem order);
        Task<UserReadDto> GetUserById(int id);
        Task<UserReadDto> CreateUser(UserCreateDto user);
        Task<UserReadDto> UpdateUser(UserReadDto user);
        Task DeleteUser(int userId);
    }
}
