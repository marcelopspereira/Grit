using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Crm;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Crm
{


    [Authorize(Roles = "Activity")]
    public class ActivityController : Controller
    {
        private readonly TriumphDbContext _context;

        public ActivityController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: Activity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activity.ToListAsync());
        }

        // GET: Activity/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                        .SingleOrDefaultAsync(m => m.activityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }


        // GET: Activity/Create
        public IActionResult Create()
        {
            Activity activity = new Activity();
            activity.colorHex = "#00a65a";
            return View();
        }




        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("activityId,activityName,description,colorHex,createdAt")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.activityId == id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("activityId,activityName,description,colorHex,createdAt")] Activity activity)
        {
            if (id != activity.activityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.activityId))
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
            return View(activity);
        }

        // GET: Activity/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                    .SingleOrDefaultAsync(m => m.activityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }




        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.activityId == id);

            try
            {
                _context.Activity.Remove(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = activity.activityId });
            }


        }

        private bool ActivityExists(string id)
        {
            return _context.Activity.Any(e => e.activityId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Activity
        {
            public const string Controller = "Activity";
            public const string Action = "Index";
            public const string Role = "Activity";
            public const string Url = "/Activity/Index";
            public const string Name = "Activity";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Activity")]
        public bool ActivityRole { get; set; } = false;
    }
}




