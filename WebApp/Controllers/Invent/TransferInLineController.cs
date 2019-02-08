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


    [Authorize(Roles = "TransferInLine")]
    public class TransferInLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public TransferInLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: TransferInLine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransferInLine.Include(t => t.product).Include(t => t.transferIn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransferInLine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferInLine = await _context.TransferInLine
                    .Include(t => t.product)
                    .Include(t => t.transferIn)
                        .SingleOrDefaultAsync(m => m.transferInLineId == id);
            if (transferInLine == null)
            {
                return NotFound();
            }

            return View(transferInLine);
        }


        // GET: TransferInLine/Create
        public IActionResult Create(string masterid, string id)
        {
            var check = _context.TransferInLine.SingleOrDefault(m => m.transferInLineId == id);
            var selected = _context.TransferIn.SingleOrDefault(m => m.transferInId == masterid);
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId");
            ViewData["transferInId"] = new SelectList(_context.TransferIn, "transferInId", "transferInId");
            if (check == null)
            {
                TransferInLine objline = new TransferInLine();
                objline.transferIn = selected;
                objline.transferInId = masterid;
                return View(objline);
            }
            else
            {
                return View(check);
            }
        }




        // POST: TransferInLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transferInLineId,transferInId,productId,qty,qtyInventory,createdAt")] TransferInLine transferInLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferInLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferInLine.productId);
            ViewData["transferInId"] = new SelectList(_context.TransferIn, "transferInId", "transferInId", transferInLine.transferInId);
            return View(transferInLine);
        }

        // GET: TransferInLine/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferInLine = await _context.TransferInLine.SingleOrDefaultAsync(m => m.transferInLineId == id);
            if (transferInLine == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferInLine.productId);
            ViewData["transferInId"] = new SelectList(_context.TransferIn, "transferInId", "transferInId", transferInLine.transferInId);
            return View(transferInLine);
        }

        // POST: TransferInLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("transferInLineId,transferInId,productId,qty,qtyInventory,createdAt")] TransferInLine transferInLine)
        {
            if (id != transferInLine.transferInLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferInLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferInLineExists(transferInLine.transferInLineId))
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
            ViewData["productId"] = new SelectList(_context.Product, "productId", "productId", transferInLine.productId);
            ViewData["transferInId"] = new SelectList(_context.TransferIn, "transferInId", "transferInId", transferInLine.transferInId);
            return View(transferInLine);
        }

        // GET: TransferInLine/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transferInLine = await _context.TransferInLine
                    .Include(t => t.product)
                    .Include(t => t.transferIn)
                    .SingleOrDefaultAsync(m => m.transferInLineId == id);
            if (transferInLine == null)
            {
                return NotFound();
            }

            return View(transferInLine);
        }




        // POST: TransferInLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transferInLine = await _context.TransferInLine.SingleOrDefaultAsync(m => m.transferInLineId == id);
            _context.TransferInLine.Remove(transferInLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferInLineExists(string id)
        {
            return _context.TransferInLine.Any(e => e.transferInLineId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class TransferInLine
        {
            public const string Controller = "TransferInLine";
            public const string Action = "Index";
            public const string Role = "TransferInLine";
            public const string Url = "/TransferInLine/Index";
            public const string Name = "TransferInLine";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "TransferInLine")]
        public bool TransferInLineRole { get; set; } = false;
    }
}




