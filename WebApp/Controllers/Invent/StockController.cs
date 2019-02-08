using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Invent
{
    [Authorize(Roles = "Stock")]
    public class StockController : Controller
    {
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
        public static class Stock
        {
            public const string Controller = "Stock";
            public const string Action = "Index";
            public const string Role = "Stock";
            public const string Url = "/Stock/Index";
            public const string Name = "Stock";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Stock")]
        public bool StockRole { get; set; } = false;
    }
}



