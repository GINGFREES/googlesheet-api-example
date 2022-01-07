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
    public class BuildingStyleController : Controller
    {
        private readonly MvcBuildingStyleContext _context;
        private BuildingStyleLogic _logic;

        public BuildingStyleController(MvcBuildingStyleContext context)
        {
            _context = context;
            _logic = new BuildingStyleLogic();
        }

        // GET: BuildingStyle
        public async Task<IActionResult> Index()
        {
            List<BuildingStyle> list = _logic.RequestBuildingStyleData();
            foreach (BuildingStyle target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.BuildingStyle.ToListAsync());
        }

        // GET: BuildingStyle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingStyle = await _context.BuildingStyle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingStyle == null)
            {
                return NotFound();
            }

            return View(buildingStyle);
        }

        // GET: BuildingStyle/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,gId,buildingStyleName,islandGid,buildingGid,buildingName,minLevel,imageKey")] BuildingStyle buildingStyle
        )
        {
            BuildingStyle target = await _context.BuildingStyle.FindAsync(buildingStyle.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(buildingStyle);
                }
            }

            if (target != null)
            {
                _context.BuildingStyle.Remove(target);
                _context.BuildingStyle.Add(buildingStyle);
            }

            await _context.SaveChangesAsync();
        }

        public string RequestBuildingStyleJson()
            => JsonConvert.SerializeObject(_logic.RequestBuildingStyleData());

        // POST: BuildingStyle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,gId,buildingStyleName,islandGid,buildingGid,buildingName,minLevel,imageKey")] BuildingStyle buildingStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingStyle);
        }

        // GET: BuildingStyle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingStyle = await _context.BuildingStyle.FindAsync(id);
            if (buildingStyle == null)
            {
                return NotFound();
            }
            return View(buildingStyle);
        }

        // POST: BuildingStyle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,gId,buildingStyleName,islandGid,buildingGid,buildingName,minLevel,imageKey")] BuildingStyle buildingStyle)
        {
            if (id != buildingStyle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingStyleExists(buildingStyle.Id))
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
            return View(buildingStyle);
        }

        // GET: BuildingStyle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingStyle = await _context.BuildingStyle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingStyle == null)
            {
                return NotFound();
            }

            return View(buildingStyle);
        }

        // POST: BuildingStyle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingStyle = await _context.BuildingStyle.FindAsync(id);
            _context.BuildingStyle.Remove(buildingStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingStyleExists(int id)
        {
            return _context.BuildingStyle.Any(e => e.Id == id);
        }
    }
}
