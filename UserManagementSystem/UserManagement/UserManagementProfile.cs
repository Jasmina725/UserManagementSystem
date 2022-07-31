using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Entity;
using UserManagementSystem.UserManagement.Models;

namespace UserManagementSystem.UserManagement
{
    public class UserManagementProfile: Profile
    {
        public UserManagementProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();
            CreateMap<UserPermission, UserPermissionViewModel>().ReverseMap();
            CreateMap<Permission, PermissionCreateDto>().ReverseMap();
        }      
    }
}
