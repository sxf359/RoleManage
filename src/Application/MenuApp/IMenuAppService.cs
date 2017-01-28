using Application.MenuApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MenuApp
{
    public interface IMenuAppService
    {
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <returns></returns>
        List<MenuDto> GetAllList();
        /// <summary>
        /// 根据父级Id获取功能列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="startPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        List<MenuDto> GetMenuByParent(long parentId, int startPage, int pageSize, out int rowCount);
        /// <summary>
        /// 新增或修改功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool InsertOrUpdate(MenuDto dto);
        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">功能Id集合</param>
        void DeleteBatch(List<long> ids);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">功能Id</param>
        void Delete(long id);
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MenuDto Get(long id);
        
    }
}
