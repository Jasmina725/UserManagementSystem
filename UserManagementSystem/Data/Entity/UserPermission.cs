using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystem.Data.Entity
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserFK { get; set; }
        [Required]
        public int PermissionFK { get; set; }

        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }             
    }
}
