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
        private readonly UserManagementContext _context;

        public PermissionRepository(UserManagementContext context)
        {
            _context = context;
        }

        public async Task AssignUserPermissions(int userId, IEnumerable<int> permissionIds)
        {
            var permissionsToAdd = permissionIds.Select(id => new UserPermission() { UserId = userId, PermissionId = id });
            await _context.UserPermissions.AddRangeAsync(permissionsToAdd);
        }

        public async Task<Permission> CreatePermission(Permission permission)
        {
            return (await _context.Permissions.AddAsync(permission)).Entity;
        }

        public async Task DeletePermission(Permission permission)
        {
            _context.Permissions.Remove(permission);
            await SaveChanges();
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
            return await _context.UserPermissions.Where(up => up.UserId.Equals(userId)).Include(a => a.Permission).ToListAsync();
        }

        public async Task RemoveUserPermissions(int userId, IEnumerable<int> permissionIds)
        {
            var remove = await _context.UserPermissions.Where(up => up.UserId.Equals(userId) && permissionIds.Contains(up.PermissionId)).ToListAsync();
            _context.UserPermissions.RemoveRange(remove);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}



