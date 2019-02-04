using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Crm
{


    [Authorize(Roles = "AccountExecutive")]
    public class AccountExecutiveController : Controller
    {
        private readonly TriumphDbContext _context;

        public AccountExecutiveController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: AccountExecutive
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountExecutive.ToListAsync());
        }

        // GET: AccountExecutive/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountExecutive = await _context.AccountExecutive
                        .SingleOrDefaultAsync(m => m.accountExecutiveId == id);
            if (accountExecutive == null)
            {
                return NotFound();
            }

            return View(accountExecutive);
        }


        // GET: AccountExecutive/Create
        public IActionResult Create()
        {
            ViewData["systemUserId"] = new SelectList(_context.ApplicationUser, "Id", "Email");

            return View();
        }




        // POST: AccountExecutive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accountExecutiveId,accountExecutiveName,description,phone,email,street1,street2,city,province,country,systemUserId,createdAt")] AccountExecutive accountExecutive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountExecutive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountExecutive);
        }

        // GET: AccountExecutive/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountExecutive = await _context.AccountExecutive.SingleOrDefaultAsync(m => m.accountExecutiveId == id);
            if (accountExecutive == null)
            {
                return NotFound();
            }
            ViewData["systemUserId"] = new SelectList(_context.ApplicationUser, "Id", "Email", accountExecutive.systemUserId);
            return View(accountExecutive);
        }

        // POST: AccountExecutive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("accountExecutiveId,accountExecutiveName,description,phone,email,street1,street2,city,province,country,systemUserId,createdAt")] AccountExecutive accountExecutive)
        {
            if (id != accountExecutive.accountExecutiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountExecutive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExecutiveExists(accountExecutive.accountExecutiveId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountExecutive);
        }

        // GET: AccountExecutive/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountExecutive = await _context.AccountExecutive
                    .SingleOrDefaultAsync(m => m.accountExecutiveId == id);
            if (accountExecutive == null)
            {
                return NotFound();
            }

            return View(accountExecutive);
        }




        // POST: AccountExecutive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountExecutive = await _context.AccountExecutive.SingleOrDefaultAsync(m => m.accountExecutiveId == id);

            try
            {
                _context.AccountExecutive.Remove(accountExecutive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = accountExecutive.accountExecutiveId });
            }


        }

        private bool AccountExecutiveExists(string id)
        {
            return _context.AccountExecutive.Any(e => e.accountExecutiveId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class AccountExecutive
        {
            public const string Controller = "AccountExecutive";
            public const string Action = "Index";
            public const string Role = "AccountExecutive";
            public const string Url = "/AccountExecutive/Index";
            public const string Name = "AccountExecutive";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "AccountExecutive")]
        public bool AccountExecutiveRole { get; set; } = false;
    }
}
