using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
namespace EntityFrameworkCore
{
    public class RoleDBContext:DbContext
    {
        public RoleDBContext(DbContextOptions<RoleDBContext> options):base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            //UserRole相关设置
            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            //RoleMenu相关设置
            builder.Entity<RoleMenu>().HasKey(rm => new { rm.RoleId, rm.MenuId });

            base.OnModelCreating(builder);
        }
    }
}
