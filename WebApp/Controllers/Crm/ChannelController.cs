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


    [Authorize(Roles = "Channel")]
    public class ChannelController : Controller
    {
        private readonly TriumphDbContext _context;

        public ChannelController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: Channel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Channel.ToListAsync());
        }

        // GET: Channel/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channel
                        .SingleOrDefaultAsync(m => m.channelId == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }


        // GET: Channel/Create
        public IActionResult Create()
        {
            Channel channel = new Channel();
            channel.colorHex = "#00a65a";
            return View(channel);
        }




        // POST: Channel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("channelId,channelName,description,colorHex,createdAt")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(channel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(channel);
        }

        // GET: Channel/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channel.SingleOrDefaultAsync(m => m.channelId == id);
            if (channel == null)
            {
                return NotFound();
            }
            return View(channel);
        }

        // POST: Channel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("channelId,channelName,description,colorHex,createdAt")] Channel channel)
        {
            if (id != channel.channelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(channel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChannelExists(channel.channelId))
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
            return View(channel);
        }

        // GET: Channel/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channel
                    .SingleOrDefaultAsync(m => m.channelId == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }




        // POST: Channel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var channel = await _context.Channel.SingleOrDefaultAsync(m => m.channelId == id);

            try
            {
                _context.Channel.Remove(channel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
                return RedirectToAction(nameof(Delete), new { id = channel.channelId });
            }


        }

        private bool ChannelExists(string id)
        {
            return _context.Channel.Any(e => e.channelId == id);
        }

    }
}





namespace WebApp.MVC
{
    public static partial class Pages
    {
        public static class Channel
        {
            public const string Controller = "Channel";
            public const string Action = "Index";
            public const string Role = "Channel";
            public const string Url = "/Channel/Index";
            public const string Name = "Channel";
        }
    }
}
namespace WebApp.Models
{
    public partial class ApplicationUser
    {
        [Display(Name = "Channel")]
        public bool ChannelRole { get; set; } = false;
    }
}




