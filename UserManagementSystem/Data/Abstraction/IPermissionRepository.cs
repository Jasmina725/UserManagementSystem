using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Abstraction
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Permission> CreatePermission(Permission permission);
        Task<Permission> GetPermissionById(int id);
        Task<IEnumerable<UserPermission>> GetUserPermissions(int userId);
        Task AssignUserPermissions(int userId, IEnumerable<int> permissionIds);
        Task RemoveUserPermissions(int userId, IEnumerable<int> permissionIds);
        Task DeletePermission(Permission permission);
        Task<bool> SaveChanges();
    }
}
