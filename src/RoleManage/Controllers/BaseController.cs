using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            byte[] result;
            context.HttpContext.Session.TryGetValue("CurrentUser", out result);
            if (result == null)
            {
                context.Result = new RedirectResult("/Login/Index");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
