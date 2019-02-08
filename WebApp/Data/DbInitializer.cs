using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using netcore.Models;
using WebApp.Services;

namespace WebApp.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(TriumphDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            INetcoreService netcoreService)
        {
            context.Database.EnsureCreated();

            //check for users
            if (context.ApplicationUser.Any())
            {
                return; //if user is not empty, DB has been seed
            }

            //init app with super admin user
            await netcoreService.CreateDefaultSuperAdmin();

            //init crm
            await netcoreService.InitCRM();

        }
    }
}
