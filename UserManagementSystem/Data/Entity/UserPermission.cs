using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystem.Data.Entity
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserFK")]
        public int UserId { get; set; }
        [ForeignKey("PermissionFK")]
        public int PermissionId { get; set; }

        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }             
    }
}
