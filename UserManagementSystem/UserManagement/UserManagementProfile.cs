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
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();
            CreateMap<UserPermission, UserPermissionViewModel>().ReverseMap();
        }
      
    }
}
