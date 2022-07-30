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
        Task<Permission> GetPermissionById(int id);
        Task<IEnumerable<UserPermission>> GetUserPermissions(int userId);
        Task AssignUserPermission(int userId, int permissionId);
        Task RemoveUserPermission(UserPermission userPermission);
        Task<bool> SaveChanges();
    }
}
