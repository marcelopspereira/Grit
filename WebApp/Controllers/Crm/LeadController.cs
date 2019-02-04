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
using WebApp.Models.Invent;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Crm
{


    [Authorize(Roles = "Lead")]
    public class LeadController : Controller
    {
        private readonly TriumphDbContext _context;

        public LeadController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: Lead
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lead.Include(l => l.accountExecutive).Include(l => l.channel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lead/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                    .Include(l => l.accountExecutive)
                    .Include(l => l.channel)
                        .SingleOrDefaultAsync(m => m.leadId == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }


        // GET: Lead/Create
        public IActionResult Create()
        {
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName");
            ViewData["channelId"] = new SelectList(_context.Channel, "channelId", "channelName");
            Lead lead = new Lead();
            lead.isQualified = false;
            lead.isConverted = false;
            return View(lead);
        }


        // POST: Lead/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("leadId,leadName,description,street1,street2,city,province,country,isQualified,isConverted,channelId,customerId,accountExecutiveId,HasChild,createdAt")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", lead.accountExecutiveId);
            ViewData["channelId"] = new SelectList(_context.Channel, "channelId", "channelName", lead.channelId);
            return View(lead);
        }

        // GET: Lead/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead.SingleOrDefaultAsync(m => m.leadId == id);
            if (lead == null)
            {
                return NotFound();
            }
            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", lead.accountExecutiveId);
            ViewData["channelId"] = new SelectList(_context.Channel, "channelId", "channelName", lead.channelId);
            return View(lead);
        }

        // POST: Lead/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("leadId,leadName,description,street1,street2,city,province,country,isQualified,isConverted,channelId,customerId,accountExecutiveId,HasChild,createdAt")] Lead lead)
        {
            if (id != lead.leadId)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    if (!lead.isQualified)
                    {
                        lead.isConverted = false;
                    }
                    if (!String.IsNullOrEmpty(lead.customerId))
                    {
                        lead.isConverted = true;
                        lead.isQualified = true;
                    }
                    _context.Update(lead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadExists(lead.leadId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }


                //convert to customer, only if customerId is still empty and already qualified
                if (lead.isQualified && lead.isConverted && String.IsNullOrEmpty(lead.customerId))
                {
                    Customer cust = new Customer();
                    cust.city = lead.city;
                    cust.country = lead.country;
                    cust.customerName = lead.leadName;
                    cust.description = lead.description;
                    cust.province = lead.province;
                    cust.street1 = lead.street1;
                    cust.street2 = lead.street2;

                    _context.Customer.Add(cust);
                    _context.SaveChanges();

                    lead.customerId = cust.customerId;
                    _context.Update(lead);
                    _context.SaveChanges();
                }


                return RedirectToAction(nameof(Index));
            }


            ViewData["accountExecutiveId"] = new SelectList(_context.AccountExecutive, "accountExecutiveId", "accountExecutiveName", lead.accountExecutiveId);
            ViewData["channelId"] = new SelectList(_context.Channel, "channelId", "channelName", lead.channelId);
            return View(lead);
        }

        // GET: Lead/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                    .Include(l => l.accountExecutive)
                    .Include(l => l.channel)
                    .Include(x => x.leadLine)
                    .SingleOrDefaultAsync(m => m.leadId == id);

            if (lead == null)
            {
                return NotFound();
            }

            ViewData["StatusMessage"] = TempData["StatusMessage"];

            return View(lead);
        }




        // POST: Lead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lead = await _context.Lead
                .Include(x => x.leadLine)
                .SingleOrDefaultAsync(m => m.leadId == id);

            if (lead.isConverted)
            {
                TempData["StatusMessage"] = "Error. Converted lead can not be deleted";
                return RedirectToAction(nameof(Delete), new { id = lead.leadId });
            }

            try
            {
                _context.LeadLine.RemoveRange(lead.leadLine);
                _context.Lead.Remove(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                TempData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = lead.leadId });
            }


        }

        private bool LeadExists(string id)
        {
            return _context.Lead.Any(e => e.leadId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Lead
        {
            public const string Controller = "Lead";
            public const string Action = "Index";
            public const string Role = "Lead";
            public const string Url = "/Lead/Index";
            public const string Name = "Lead";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Lead")]
        public bool LeadRole { get; set; } = false;
    }
}




