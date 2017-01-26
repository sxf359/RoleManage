using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
namespace EntityFrameworkCore
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoleDBContext(serviceProvider.GetRequiredService<DbContextOptions<RoleDBContext>>()))
            {
                if (context.Users.Any())
                {
                    return;//已经初始化过数据，返回。
                }
                long departmentId= Convert.ToInt64(System.DateTime.Now.ToString("yyyyMMddhhmmss"));
                context.Departments.Add(
                    new Department { Id = departmentId, Name = "集团总部", ParentId = 0 }
                    );
                context.Users.Add(
                    new User { UserName="admin",Password="123456",Name="超级管理员",DepartmentId=departmentId}
                    );
                context.Menus.AddRange(
                    new Menu { Name = "组织机构管理", Code = "Department", SerialNumber = 0, ParentId = 0, Icon = "fa fa-link" },
                    new Menu { Name = "角色管理", Code = "Role", SerialNumber = 1, ParentId = 0,Icon="fa fa-link" },
                    new Menu { Name="用户管理",Code="User",SerialNumber=2,ParentId=0,Icon="fa fa-link"},
                    new Menu { Name="功能管理",Code="Department",SerialNumber=3,ParentId=0,Icon="fa fa-link"}
                    );

                context.SaveChanges();
            }
        }
    }
}
