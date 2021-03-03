using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1ére_application_web_ASP.NET_CORE.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
