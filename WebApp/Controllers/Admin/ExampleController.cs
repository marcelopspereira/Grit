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
        public IActionResult Invoice()
        {
            return View();
        }

        public IActionResult InvoicePrint()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Lockscreen()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

        public IActionResult BlankPage()
        {
            return View();
        }

        public IActionResult PacePage()
        {
            return View();
        }
    }
}
