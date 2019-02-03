using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Admin
{
    public partial class AdminlteController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Advanced()
        {
            return View();
        }

        public IActionResult Editor()
        {
            return View();
        }
    }
}