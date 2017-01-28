using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.MenuApp;
using MVC.Models;
using Application.MenuApp.Dtos;
using Domain.Entities;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    /// <summary>
    /// 功能管理控制器
    /// </summary>
    public class MenuController : Controller
    {
        private readonly IMenuAppService _menuAppService;

        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取功能树JSON数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuTreeData()
        {
            var menus = _menuAppService.GetAllList();
            List<TreeModel> treeeModels = new List<TreeModel>();
            foreach (var menu in menus)
            {
                treeeModels.Add(new TreeModel() { Id=menu.Id.ToString(),Text=menu.Name,Parent = menu.ParentId == 0?"#":menu.ParentId.ToString() });
            }
            return Json(treeeModels);
        }
        /// <summary>
        /// 获取子级功能列表
        /// </summary>
        /// <param name="parendId"></param>
        /// <param name="startPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IActionResult GetMenusByParent(long parendId,int startPage,int pageSize)
        {
            int rowCount = 0;
            var result = _menuAppService.GetMenuByParent(parendId, startPage, pageSize, out rowCount);
            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result
            });
        }

        public IActionResult Edit(MenuDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result="Faild",
                    Message=GetMenuStateError()
                });
            }
            if (_menuAppService.InsertOrUpdate(dto))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }
        private string GetMenuStateError()
        {
            return "111";
        }

        public IActionResult DeleteMuti(string ids)
        {
            try
            {
                string[] idArray = ids.Split(',');
                List<long> delIds = new List<long>();
                foreach (string id in idArray)
                {
                    delIds.Add(Convert.ToInt64(id));
                }
                _menuAppService.DeleteBatch(delIds);
                return Json(new { Result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Delete(long id)
        {
            try
            {
                _menuAppService.Delete(id);
                return Json(new
                {
                    Result="Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new {Result="Faild",Message=ex.Message });
            }
        }

        public IActionResult Get(long id)
        {
            var dto = _menuAppService.Get(id);
            return Json(dto);
        }
    }
}
