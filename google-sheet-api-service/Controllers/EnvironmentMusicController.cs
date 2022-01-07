#nullable disable
using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;
using google_sheet_api_service.Controllers.Logics;
using Newtonsoft.Json;

namespace google_sheet_api_service.Controllers
{
    public class EnvironmentMusicController : Controller
    {
        private readonly MvcEnvironmentMusicContext _context;
        private EnvironmentMusicLogic _logic;

        public EnvironmentMusicController(MvcEnvironmentMusicContext context)
        {
            _context = context;
            _logic = new EnvironmentMusicLogic();
        }

        // GET: EnvironmentMusic
        public async Task<IActionResult> Index()
        {
            var list = _logic.RequestEnvironmentMusic();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.EnvironmentMusic.ToListAsync());
        }

        // GET: EnvironmentMusic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentMusic = await _context.EnvironmentMusic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentMusic == null)
            {
                return NotFound();
            }

            return View(environmentMusic);
        }

        public string RquestEnvironmentMusicJson()
            => JsonConvert.SerializeObject(_logic.RequestEnvironmentMusic());

        // GET: EnvironmentMusic/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,islandGid,islandName,music,isLoop,startDelay,isFadeLoop,fadeLoopDelay,fadeOutDelay,fadeInOutDuration,fadeInOutEase")] EnvironmentMusic environmentMusic
        )
        {
            var target = await _context.EnvironmentMusic.FindAsync(environmentMusic.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(environmentMusic);
                }
            }
            else
            {
                _context.EnvironmentMusic.Remove(target);
                _context.Add(environmentMusic);
            }
            await _context.SaveChangesAsync();
        }

        // POST: EnvironmentMusic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,islandGid,islandName,music,isLoop,startDelay,isFadeLoop,fadeLoopDelay,fadeOutDelay,fadeInOutDuration,fadeInOutEase")] EnvironmentMusic environmentMusic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(environmentMusic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(environmentMusic);
        }

        // GET: EnvironmentMusic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentMusic = await _context.EnvironmentMusic.FindAsync(id);
            if (environmentMusic == null)
            {
                return NotFound();
            }
            return View(environmentMusic);
        }

        // POST: EnvironmentMusic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,islandGid,islandName,music,isLoop,startDelay,isFadeLoop,fadeLoopDelay,fadeOutDelay,fadeInOutDuration,fadeInOutEase")] EnvironmentMusic environmentMusic)
        {
            if (id != environmentMusic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(environmentMusic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvironmentMusicExists(environmentMusic.Id))
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
            return View(environmentMusic);
        }

        // GET: EnvironmentMusic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentMusic = await _context.EnvironmentMusic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentMusic == null)
            {
                return NotFound();
            }

            return View(environmentMusic);
        }

        // POST: EnvironmentMusic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var environmentMusic = await _context.EnvironmentMusic.FindAsync(id);
            _context.EnvironmentMusic.Remove(environmentMusic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvironmentMusicExists(int id)
        {
            return _context.EnvironmentMusic.Any(e => e.Id == id);
        }
    }
}
