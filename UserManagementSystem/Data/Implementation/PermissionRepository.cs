using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Abstraction;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        UserManagementContext _context;

        public PermissionRepository(UserManagementContext context)
        {
            _context = context;
        }

        public async Task AssignUserPermission(int userId, int permissionId)
        {
            await _context.UserPermissions.AddAsync(new UserPermission() { UserFK = userId, PermissionFK = permissionId });
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await _context.Permissions.FirstOrDefaultAsync(permission => permission.Id.Equals(id));
        }

        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<IEnumerable<UserPermission>> GetUserPermissions(int userId)
        {
            return await _context.UserPermissions.Where(up => up.UserFK.Equals(userId)).Include(a => a.Permission).ToListAsync();
        }

        public async Task RemoveUserPermission(UserPermission userPermission)
        {
            _context.UserPermissions.Remove(userPermission);
            await SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
