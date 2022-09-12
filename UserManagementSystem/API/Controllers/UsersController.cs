using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserManager _manager;

        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<UserReadDto>>> GetUsers([FromQuery]PageItem page, [FromQuery]FilterItem filter, [FromQuery]OrderItem order)
        {
            var users = await _manager.GetUsers(page, filter, order);
            return ApiResponse<IEnumerable<UserReadDto>>.Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<UserReadDto>> GetUserById([FromRoute] int id)
        {
            var aa = HttpContext.Request;
            var user = await _manager.GetUserById(id);
            return ApiResponse<UserReadDto>.Ok(user);
        }

        [HttpPost]
        public async Task<ApiResponse<UserReadDto>> CreateUser([FromBody] UserCreateDto user)
        {
            var createdUser = await _manager.CreateUser(user);
            return ApiResponse<UserReadDto>.Ok(createdUser);
        }

        [HttpPut]
        public async Task<ApiResponse<UserReadDto>> UpdateUser([FromBody] UserReadDto user)
        {
            var updatedUser = await _manager.UpdateUser(user);
            return ApiResponse<UserReadDto>.Ok(updatedUser);

        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<UserReadDto>> DeleteUser(int id)
        {
            await _manager.DeleteUser(id);
            return ApiResponse<UserReadDto>.Ok();
        }
    }
}
