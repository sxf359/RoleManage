using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class HomeController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // throw new Exception("�쳣");
            return View();
        }
    }
}
