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
    [Route("api/ReceivingLine")]
    public class ReceivingLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public ReceivingLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: api/ReceivingLine
        [HttpGet]
        [Authorize]
        public IActionResult GetReceivingLine(string masterid)
        {
            return Json(new { data = _context.ReceivingLine.Include(x => x.product).Where(x => x.receivingId.Equals(masterid)).ToList() });
        }

        // POST: api/ReceivingLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostReceivingLine([FromBody] ReceivingLine receivingLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (receivingLine.receivingLineId == string.Empty)
            {
                receivingLine.receivingLineId = Guid.NewGuid().ToString();
                _context.ReceivingLine.Add(receivingLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(receivingLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/ReceivingLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReceivingLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receivingLine = await _context.ReceivingLine.SingleOrDefaultAsync(m => m.receivingLineId == id);
            if (receivingLine == null)
            {
                return NotFound();
            }

            _context.ReceivingLine.Remove(receivingLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool ReceivingLineExists(string id)
        {
            return _context.ReceivingLine.Any(e => e.receivingLineId == id);
        }


    }

}

