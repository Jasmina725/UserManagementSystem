using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Common;
using UserManagementSystem.Data.Abstraction;
using UserManagementSystem.Data.Entity;
using UserManagementSystem.UserManagement.Abstraction;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.UserManagement.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;                
        }

        public async Task<UserReadDto> CreateUser(UserCreateDto user)
        {
            if (user == null)
                throw new ArgumentNullException("User coudn't be empty");

            if ((int)user.Status > 1)
                throw new AppException("Status value is not valid.");

            var entity = _mapper.Map<User>(user);
            entity = await _repository.CreateUser(entity);
            await _repository.SaveChanges();

            return _mapper.Map<UserReadDto>(entity);
        }

        public async Task DeleteUser(int userId)
        {
            var entity = await _repository.GetUserById(userId);
            if (entity == null)
                throw new KeyNotFoundException("User with specified id not found.");
            await _repository.DeleteUser(entity);
        }

        public async Task<UserReadDto> GetUserById(int id)
        {
            var entity = await _repository.GetUserById(id);
            if (entity == null)
                throw new KeyNotFoundException("User with specified id not found.");
            return _mapper.Map<UserReadDto>(entity);
        }

        public async Task<IEnumerable<UserReadDto>> GetUsers(PageItem page, FilterItem filter, OrderItem order)
        {
            var users = await _repository.GetUsers(page, filter, order);
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> UpdateUser(UserReadDto user)
        {
            var entity = await _repository.GetUserById(user.Id);

            if (entity == null)
                throw new KeyNotFoundException("User with specified id not found.");

            entity = _mapper.Map(user, entity);
            await _repository.SaveChanges();

            return _mapper.Map<UserReadDto>(entity);
        }
    }
}
