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
using WebApp.Models.Invent;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Invent
{


    [Authorize(Roles = "TransferOrderLine")]
    public class TransferOrderLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public TransferOrderLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: TransferOrderLine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransferOrderLine.Include(t => t.product).Include(t => t.transferOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransferOrderLine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrderLine = await _context.TransferOrderLine
                    .Include(t => t.product)
                    .Include(t => t.transferOrder)
                        .SingleOrDefaultAsync(m => m.transferOrderLineId == id);
            if (transferOrderLine == null)
            {
                return NotFound();
            }

            return View(transferOrderLine);
        }


        // GET: TransferOrderLine/Create
        public IActionResult Create(string masterid, string id)
        {
            var check = _context.TransferOrderLine.SingleOrDefault(m => m.transferOrderLineId == id);
            var selected = _context.TransferOrder.SingleOrDefault(m => m.transferOrderId == masterid);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode");
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber");
            if (check == null)
            {
                TransferOrderLine objline = new TransferOrderLine();
                objline.transferOrder = selected;
                objline.transferOrderId = masterid;
                return View(objline);
            }
            else
            {
                return View(check);
            }
        }




        // POST: TransferOrderLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transferOrderLineId,transferOrderId,productId,qty,createdAt")] TransferOrderLine transferOrderLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferOrderLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", transferOrderLine.productId);
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOrderLine.transferOrderId);
            return View(transferOrderLine);
        }

        // GET: TransferOrderLine/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrderLine = await _context.TransferOrderLine.SingleOrDefaultAsync(m => m.transferOrderLineId == id);
            if (transferOrderLine == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", transferOrderLine.productId);
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOrderLine.transferOrderId);
            return View(transferOrderLine);
        }

        // POST: TransferOrderLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("transferOrderLineId,transferOrderId,productId,qty,createdAt")] TransferOrderLine transferOrderLine)
        {
            if (id != transferOrderLine.transferOrderLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferOrderLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferOrderLineExists(transferOrderLine.transferOrderLineId))
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
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productCode", transferOrderLine.productId);
            ViewData["transferOrderId"] = new SelectList(_context.TransferOrder, "transferOrderId", "transferOrderNumber", transferOrderLine.transferOrderId);
            return View(transferOrderLine);
        }

        // GET: TransferOrderLine/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferOrderLine = await _context.TransferOrderLine
                    .Include(t => t.product)
                    .Include(t => t.transferOrder)
                    .SingleOrDefaultAsync(m => m.transferOrderLineId == id);
            if (transferOrderLine == null)
            {
                return NotFound();
            }

            return View(transferOrderLine);
        }




        // POST: TransferOrderLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transferOrderLine = await _context.TransferOrderLine.SingleOrDefaultAsync(m => m.transferOrderLineId == id);
            _context.TransferOrderLine.Remove(transferOrderLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferOrderLineExists(string id)
        {
            return _context.TransferOrderLine.Any(e => e.transferOrderLineId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class TransferOrderLine
        {
            public const string Controller = "TransferOrderLine";
            public const string Action = "Index";
            public const string Role = "TransferOrderLine";
            public const string Url = "/TransferOrderLine/Index";
            public const string Name = "TransferOrderLine";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "TransferOrderLine")]
        public bool TransferOrderLineRole { get; set; } = false;
    }
}



