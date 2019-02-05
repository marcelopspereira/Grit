using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Home")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation(LoggingEvents.ListItems, "Listing Home Index");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            _logger.LogInformation(LoggingEvents.ListItems, "Listing Home About");

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            _logger.LogInformation(LoggingEvents.ListItems, "Listing Home Contact");

            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Home
        {
            public const string Controller = "Home";
            public const string Action = "Index";
            public const string Role = "Home";
            public const string Url = "/Home/Index";
            public const string Name = "Home";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Home")]
        public bool HomeRole { get; set; } = false;
    }
}