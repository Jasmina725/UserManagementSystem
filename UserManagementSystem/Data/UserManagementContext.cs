using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Data.Entity;

namespace UserManagementSystem.Data
{
    public class UserManagementContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
       

        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Permission> permissions = new List<Permission>
            {
                new Permission() { Id = 1, Code = "Admin", Description = "This is an admin permission."},
                new Permission() { Id = 2, Code = "Editor", Description = "This is a editor permission."},
                new Permission() { Id = 3, Code = "Reader", Description = "This is a reader permission."}
            };

            IEnumerable<User> users = new List<User>
            {
                new User() { Id  = 1, FirstName = "First", LastName = "Last", Email = "firstUser@sth.com", UserName = "userName", Password="userPassword", Status = 0 },
            };

            modelBuilder.Entity<Permission>().HasData(permissions);
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
