using System;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IRoles
    {
        Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentUserLogin);
    }
}
