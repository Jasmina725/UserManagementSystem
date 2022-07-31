using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Common;
using UserManagementSystem.UserManagement.Abstraction;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : Controller
    {
        private readonly IPermissionManager _manager;

        public PermissionsController(IPermissionManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<PermissionViewModel>>> GetPermissions()
        {
            var permissions = await _manager.GetPermissions();
            return ApiResponse<IEnumerable<PermissionViewModel>>.Ok(permissions);
        }

        [HttpPost]
        public async Task<ApiResponse<PermissionViewModel>> CreatePermission([FromBody] PermissionCreateDto permission)
        {
            var createdPermission = await _manager.CreatePermission(permission);
            return ApiResponse<PermissionViewModel>.Ok(createdPermission);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<PermissionViewModel>> DeletePermission(int id)
        {
            await _manager.DeletePermission(id);
            return ApiResponse<PermissionViewModel>.Ok();
        }

        [HttpGet("user-permissions")]
        public async Task<ApiResponse<IEnumerable<PermissionViewModel>>> GetUserPermissions([FromQuery] int userId)
        {
            var permissions = await _manager.GetUserPermissions(userId);
            return ApiResponse<IEnumerable<PermissionViewModel>>.Ok(permissions);
        }

        [HttpPut("user-permissions")]
        public async Task<ApiResponse<PermissionViewModel>> UpdateUserPermissions([FromBody] UserPermissionViewModel userPermissions)
        {
            await _manager.UpdateUserPermissions(userPermissions);
            return ApiResponse<PermissionViewModel>.Ok();
        }

    }
}
