using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.UserApp.Dtos;
namespace Application.UserApp
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);
        List<UserDto> GetUserByDepartment(long departmentId, int startPage, int pageSize, out int rowCount);
        UserDto InsertOrUpdate(UserDto dto);

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids">ID集合</param>
        void DeleteBatch(List<long> ids);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void Delet(long id);
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDto Get(long id);
    }
}
