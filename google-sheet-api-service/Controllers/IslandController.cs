#nullable disable
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
    public class IslandController : Controller
    {
        private readonly MvcIslandContext _context;
        private IslandLogic _logic;

        public IslandController(MvcIslandContext context)
        {
            _context = context;
            _logic = new IslandLogic();
        }

        // GET: Island
        public async Task<IActionResult> Index()
        {
            List<Island> list = _logic.RequestIslandData();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.Island.ToListAsync());
        }

        // GET: Island/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var island = await _context.Island
                .FirstOrDefaultAsync(m => m.Id == id);
            if (island == null)
            {
                return NotFound();
            }

            return View(island);
        }

        // GET: Island/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,gId,islandName,imageKey,nameKey,descriptionKey,conclusionKey")] Island island
        )
        {
            Island target = await _context.Island.FindAsync(island.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(island);
                }
            }
            else
            {
                _context.Island.Remove(target);
                _context.Add(island);
            }

            await _context.SaveChangesAsync();
        }

        // POST: Island/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,gId,islandName,imageKey,nameKey,descriptionKey,conclusionKey")] Island island)
        {
            if (ModelState.IsValid)
            {
                _context.Add(island);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(island);
        }

        // GET: Island/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var island = await _context.Island.FindAsync(id);
            if (island == null)
            {
                return NotFound();
            }
            return View(island);
        }

        // POST: Island/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,gId,islandName,imageKey,nameKey,descriptionKey,conclusionKey")] Island island)
        {
            if (id != island.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(island);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslandExists(island.Id))
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
            return View(island);
        }

        // GET: Island/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var island = await _context.Island
                .FirstOrDefaultAsync(m => m.Id == id);
            if (island == null)
            {
                return NotFound();
            }

            return View(island);
        }

        // POST: Island/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var island = await _context.Island.FindAsync(id);
            _context.Island.Remove(island);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslandExists(int id)
        {
            return _context.Island.Any(e => e.Id == id);
        }
    }
}
