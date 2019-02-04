using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Crm;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Crm
{


    [Authorize(Roles = "OpportunityLine")]
    public class OpportunityLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public OpportunityLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: OpportunityLine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OpportunityLine.Include(o => o.activity).Include(o => o.opportunity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OpportunityLine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityLine = await _context.OpportunityLine
                    .Include(o => o.activity)
                    .Include(o => o.opportunity)
                        .SingleOrDefaultAsync(m => m.opportunityLineId == id);
            if (opportunityLine == null)
            {
                return NotFound();
            }

            return View(opportunityLine);
        }


        // GET: OpportunityLine/Create
        public IActionResult Create(string masterid, string id)
        {
            var check = _context.OpportunityLine.SingleOrDefault(m => m.opportunityLineId == id);
            var selected = _context.Opportunity.SingleOrDefault(m => m.opportunityId == masterid);
            ViewData["activityId"] = new SelectList(_context.Activity, "activityId", "activityName");
            ViewData["opportunityId"] = new SelectList(_context.Opportunity, "opportunityId", "opportunityName");
            if (check == null)
            {
                OpportunityLine objline = new OpportunityLine();
                objline.opportunity = selected;
                objline.opportunityId = masterid;
                return View(objline);
            }
            else
            {
                return View(check);
            }
        }




        // POST: OpportunityLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("opportunityLineId,opportunityId,activityId,startDate,endDate,description,createdAt")] OpportunityLine opportunityLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opportunityLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["activityId"] = new SelectList(_context.Activity, "activityId", "activityName", opportunityLine.activityId);
            ViewData["opportunityId"] = new SelectList(_context.Opportunity, "opportunityId", "opportunityName", opportunityLine.opportunityId);
            return View(opportunityLine);
        }

        // GET: OpportunityLine/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityLine = await _context.OpportunityLine.SingleOrDefaultAsync(m => m.opportunityLineId == id);
            if (opportunityLine == null)
            {
                return NotFound();
            }
            ViewData["activityId"] = new SelectList(_context.Activity, "activityId", "activityName", opportunityLine.activityId);
            ViewData["opportunityId"] = new SelectList(_context.Opportunity, "opportunityId", "opportunityName", opportunityLine.opportunityId);
            return View(opportunityLine);
        }

        // POST: OpportunityLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("opportunityLineId,opportunityId,activityId,startDate,endDate,description,createdAt")] OpportunityLine opportunityLine)
        {
            if (id != opportunityLine.opportunityLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunityLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityLineExists(opportunityLine.opportunityLineId))
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
            ViewData["activityId"] = new SelectList(_context.Activity, "activityId", "activityName", opportunityLine.activityId);
            ViewData["opportunityId"] = new SelectList(_context.Opportunity, "opportunityId", "opportunityName", opportunityLine.opportunityId);
            return View(opportunityLine);
        }

        // GET: OpportunityLine/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityLine = await _context.OpportunityLine
                    .Include(o => o.activity)
                    .Include(o => o.opportunity)
                    .SingleOrDefaultAsync(m => m.opportunityLineId == id);
            if (opportunityLine == null)
            {
                return NotFound();
            }

            return View(opportunityLine);
        }




        // POST: OpportunityLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var opportunityLine = await _context.OpportunityLine.SingleOrDefaultAsync(m => m.opportunityLineId == id);
            _context.OpportunityLine.Remove(opportunityLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityLineExists(string id)
        {
            return _context.OpportunityLine.Any(e => e.opportunityLineId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class OpportunityLine
        {
            public const string Controller = "OpportunityLine";
            public const string Action = "Index";
            public const string Role = "OpportunityLine";
            public const string Url = "/OpportunityLine/Index";
            public const string Name = "OpportunityLine";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "OpportunityLine")]
        public bool OpportunityLineRole { get; set; } = false;
    }
}



