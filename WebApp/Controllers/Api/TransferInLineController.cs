using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Invent;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers.Api
{

    [Produces("application/json")]
    [Route("api/TransferInLine")]
    public class TransferInLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public TransferInLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: api/TransferInLine
        [HttpGet]
        [Authorize]
        public IActionResult GetTransferInLine(string masterid)
        {
            return Json(new { data = _context.TransferInLine.Include(x => x.product).Where(x => x.transferInId.Equals(masterid)).ToList() });
        }

        // POST: api/TransferInLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostTransferInLine([FromBody] TransferInLine transferInLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (transferInLine.transferInLineId == string.Empty)
            {
                transferInLine.transferInLineId = Guid.NewGuid().ToString();
                _context.TransferInLine.Add(transferInLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(transferInLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/TransferInLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransferInLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transferInLine = await _context.TransferInLine.SingleOrDefaultAsync(m => m.transferInLineId == id);
            if (transferInLine == null)
            {
                return NotFound();
            }

            _context.TransferInLine.Remove(transferInLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool TransferInLineExists(string id)
        {
            return _context.TransferInLine.Any(e => e.transferInLineId == id);
        }


    }

}