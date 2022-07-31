using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.UserManagement.Abstraction
{
    public interface IPermissionManager
    {
        Task<IEnumerable<PermissionViewModel>> GetPermissions();
        Task<IEnumerable<PermissionViewModel>> GetUserPermissions(int userId);
        Task UpdateUserPermissions(UserPermissionViewModel userPermission);
        Task<PermissionViewModel> CreatePermission(PermissionCreateDto permission);
        Task DeletePermission(int id);
    }
}
