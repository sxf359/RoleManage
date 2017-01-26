using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    //用户管理仓储接口定义
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 检测用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        User CheckUser(string userName, string password);
    }
}
