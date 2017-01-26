using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserApp.Dtos;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.UserApp
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserAppService : IUserAppService
    {
        //用户管理仓储接口
        private readonly IUserRepository  _userRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CheckUser(string userName, string password)
        {
            return _userRepository.CheckUser(userName, password);
        }

        public void Delet(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBatch(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public UserDto Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUserByDepartment(long departmentId, int startPage, int pageSize, out int rowCount)
        {
            throw new NotImplementedException();
        }

        public UserDto InsertOrUpdate(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
