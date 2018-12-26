using System;
namespace Grit.Web.MVC
{
    public static partial class Pages
    {

        public static class HomeIndex
        {
            public const string Controller = "Home";
            public const string Action = "Index";
            public const string Role = "Home";
            public const string Url = "/Home/Index";
            public const string Name = "Home";
        }

        public static class ApplicationUser
        {
            public const string Controller = "ApplicationUser";
            public const string Action = "Index";
            public const string Role = "ApplicationUser";
            public const string Url = "/ApplicationUser/Index";
            public const string Name = "User Role";
        }

    }
}

