using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.UserApp;
using MVC.Models;
using Utility;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace  MVC.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = _userAppService.CheckUser("admin", "123456");
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //检测用户信息
                var user = _userAppService.CheckUser(model.UserName, model.Password);
                if (user!=null)
                {
                    //记录session
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    //jmp to 系统首页
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "用户名或密码错误");
                return View();
            }
            return View(model);
        }
    }
}
