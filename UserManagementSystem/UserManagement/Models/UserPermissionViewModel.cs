using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystem.UserManagement.Models
{
    public class UserPermissionViewModel
    {
        public int UserId { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}
