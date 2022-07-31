using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Abstraction;
using UserManagementSystem.Data.Entity;
using UserManagementSystem.UserManagement.Abstraction;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.UserManagement.Implementation
{
    public class PermissionManager: IPermissionManager
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public PermissionManager(IPermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PermissionViewModel> CreatePermission(PermissionCreateDto permission)
        {
            if (permission == null)
                throw new ArgumentNullException("Permission coudn't be empty");

            var entity = _mapper.Map<Permission>(permission);
            entity = await _repository.CreatePermission(entity);
            await _repository.SaveChanges();

            return _mapper.Map<PermissionViewModel>(entity);
        }

        public async Task DeletePermission(int id)
        {
            var entity = await _repository.GetPermissionById(id);
            if (entity == null)
                throw new KeyNotFoundException("Permission with specified id not found.");
            await _repository.DeletePermission(entity);
        }

        public async Task<IEnumerable<PermissionViewModel>> GetPermissions()
        {
            var permissions = await _repository.GetPermissions();
            return _mapper.Map<IEnumerable<PermissionViewModel>>(permissions);
        }

        public async Task<IEnumerable<PermissionViewModel>> GetUserPermissions(int userId)
        {
            var userPermissions = (await _repository.GetUserPermissions(userId)).Select(p => p.Permission).ToList();
            return _mapper.Map<IEnumerable<PermissionViewModel>>(userPermissions);
        }



        public async Task UpdateUserPermissions(UserPermissionViewModel userPermission)
        {
            var currentPermissions = (await _repository.GetUserPermissions(userPermission.UserId)).Select(up => up.PermissionId);

            var toAddPermissions = userPermission.PermissionIds.Except(currentPermissions);
            var toRemovePermissions = currentPermissions.Except(userPermission.PermissionIds);

            await _repository.AssignUserPermissions(userPermission.UserId, toAddPermissions);
            await _repository.RemoveUserPermissions(userPermission.UserId, toRemovePermissions);

            await _repository.SaveChanges();
            
        }
    }
}
