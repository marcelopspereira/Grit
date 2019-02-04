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


    [Authorize(Roles = "Opportunity")]
    public class OpportunityController : Controller
    {
        private readonly TriumphDbContext _context;

        public OpportunityController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: Opportunity
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Opportunity.Include(o => o.accountExecutive).Include(o => o.customer).Include(o => o.rating).Include(o => o.stage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Opportunity/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                    .Include(o => o.accountExecutive)
                    .Include(o => o.customer)
                    .Include(o => o.rating)
                    .Include(o => o.stage)
                        .SingleOrDefaultAsync(m => m.opportunityId == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }


        // GET: Opportunity/Create
        public IActionResult Create()
        {
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName");
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName");
            ViewData["ratingId"] = new SelectList(_context.Rating, "ratingId", "ratingName");
            ViewData["stageId"] = new SelectList(_context.Stage, "stageId", "stageName");

            Opportunity opp = new Opportunity();
            opp.estimatedClosingDate = DateTime.UtcNow;
            return View(opp);
        }




        // POST: Opportunity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("opportunityId,opportunityName,description,stageId,accountExecutiveId,customerId,estimatedRevenue,estimatedClosingDate,probability,ratingId,HasChild,createdAt")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                if (opportunity.probability > 100)
                {
                    opportunity.probability = 100;
                }
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", opportunity.accountExecutiveId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", opportunity.customerId);
            ViewData["ratingId"] = new SelectList(_context.Rating, "ratingId", "ratingName", opportunity.ratingId);
            ViewData["stageId"] = new SelectList(_context.Stage, "stageId", "stageName", opportunity.stageId);
            return View(opportunity);
        }

        // GET: Opportunity/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity.SingleOrDefaultAsync(m => m.opportunityId == id);
            if (opportunity == null)
            {
                return NotFound();
            }
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", opportunity.accountExecutiveId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", opportunity.customerId);
            ViewData["ratingId"] = new SelectList(_context.Rating, "ratingId", "ratingName", opportunity.ratingId);
            ViewData["stageId"] = new SelectList(_context.Stage, "stageId", "stageName", opportunity.stageId);
            return View(opportunity);
        }

        // POST: Opportunity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("opportunityId,opportunityName,description,stageId,accountExecutiveId,customerId,estimatedRevenue,estimatedClosingDate,probability,ratingId,HasChild,createdAt")] Opportunity opportunity)
        {
            if (id != opportunity.opportunityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.opportunityId))
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
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", opportunity.accountExecutiveId);
            ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerName", opportunity.customerId);
            ViewData["ratingId"] = new SelectList(_context.Rating, "ratingId", "ratingName", opportunity.ratingId);
            ViewData["stageId"] = new SelectList(_context.Stage, "stageId", "stageName", opportunity.stageId);
            return View(opportunity);
        }

        // GET: Opportunity/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                    .Include(o => o.accountExecutive)
                    .Include(o => o.customer)
                    .Include(o => o.rating)
                    .Include(o => o.stage)
                    .SingleOrDefaultAsync(m => m.opportunityId == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }




        // POST: Opportunity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var opportunity = await _context.Opportunity
                .Include(x => x.opportunityLine)
                .SingleOrDefaultAsync(m => m.opportunityId == id);

            try
            {
                _context.OpportunityLine.RemoveRange(opportunity.opportunityLine);
                _context.Opportunity.Remove(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = opportunity.opportunityId });
            }


        }

        private bool OpportunityExists(string id)
        {
            return _context.Opportunity.Any(e => e.opportunityId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Opportunity
        {
            public const string Controller = "Opportunity";
            public const string Action = "Index";
            public const string Role = "Opportunity";
            public const string Url = "/Opportunity/Index";
            public const string Name = "Opportunity";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Opportunity")]
        public bool OpportunityRole { get; set; } = false;
    }
}




