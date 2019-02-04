using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Crm
{
    [Authorize(Roles = "Dashboard")]
    public class DashboardController : Controller
    {
        private readonly ILogger _logger;

        public DashboardController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Dashboard
        {
            public const string Controller = "Dashboard";
            public const string Action = "Index";
            public const string Role = "Dashboard";
            public const string Url = "/Dashboard/Index";
            public const string Name = "Dashboard";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Dashboard")]
        public bool DashboardRole { get; set; } = false;
    }
}
