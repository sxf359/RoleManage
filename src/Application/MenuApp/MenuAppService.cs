using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MenuApp.Dtos;
using Domain.IRepositories;
using AutoMapper;
using Domain.Entities;

namespace Application.MenuApp
{
    public class MenuAppService : IMenuAppService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuAppService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public void Delete(long id)
        {
            _menuRepository.Delete(id);
        }

        public void DeleteBatch(List<long> ids)
        {
            _menuRepository.Delete(it => ids.Contains(it.Id));
        }

        public MenuDto Get(long id)
        {
            return Mapper.Map<MenuDto>(_menuRepository.Get(id));
        }

        public List<MenuDto> GetAllList()
        {
            var menus = _menuRepository.GetAllList().OrderBy(it => it.SerialNumber);
            //使用AutoMapper进行实体转换
            return Mapper.Map<List<MenuDto>>(menus);
        }

        public List<MenuDto> GetMenuByParent(long parentId, int startPage, int pageSize, out int rowCount)
        {
            var menus = _menuRepository.LoadPageList(startPage, pageSize, out rowCount, it => it.ParentId == parentId,it=>it.SerialNumber);
            return Mapper.Map<List<MenuDto>>(menus);
        }

        public bool InsertOrUpdate(MenuDto dto)
        {
            var menu = _menuRepository.InsertOrUpdate(Mapper.Map<Menu>(dto));
            return menu == null ? false : true;
        }
    }
}
