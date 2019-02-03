﻿using System;
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
    [Route("api/ShipmentLine")]
    public class ShipmentLineController : Controller
    {
        private readonly TriumphDbContext _context;

        public ShipmentLineController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentLine
        [HttpGet]
        [Authorize]
        public IActionResult GetShipmentLine(string masterid)
        {
            return Json(new { data = _context.ShipmentLine.Include(x => x.product).Where(x => x.shipmentId.Equals(masterid)).ToList() });
        }

        // POST: api/ShipmentLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostShipmentLine([FromBody] ShipmentLine shipmentLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (shipmentLine.shipmentLineId == string.Empty)
            {
                shipmentLine.shipmentLineId = Guid.NewGuid().ToString();
                _context.ShipmentLine.Add(shipmentLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(shipmentLine);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/ShipmentLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteShipmentLine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipmentLine = await _context.ShipmentLine.SingleOrDefaultAsync(m => m.shipmentLineId == id);
            if (shipmentLine == null)
            {
                return NotFound();
            }

            _context.ShipmentLine.Remove(shipmentLine);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        private bool ShipmentLineExists(string id)
        {
            return _context.ShipmentLine.Any(e => e.shipmentLineId == id);
        }


    }

}

