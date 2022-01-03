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
    public class BuildingLevelController : Controller
    {
        private readonly MvcBuildingLevelContext _context;
        private BuildingLevelLogic _buildingLevelLogic;

        public BuildingLevelController(MvcBuildingLevelContext context)
        {
            _context = context;
            _buildingLevelLogic = new BuildingLevelLogic();
        }

        // GET: BuildingLevel
        public async Task<IActionResult> Index()
        {
            List<BuildingLevel> list = _buildingLevelLogic.RequestBuildingLevelData();
            foreach (BuildingLevel buildingLevel in list)
            {
                await CreateOrUpdate(buildingLevel);
                Console.WriteLine($"Create or update : {JsonConvert.SerializeObject(buildingLevel)}");
            }
            return View(await _context.BuildingLevel.ToListAsync());
        }

        // GET: BuildingLevel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevel = await _context.BuildingLevel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingLevel == null)
            {
                return NotFound();
            }

            return View(buildingLevel);
        }

        // GET: BuildingLevel/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task CleanUp()
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE * FROM Building");
        }

        private async Task CreateOrUpdate([Bind("Id,buildingName,buildingLevel")] BuildingLevel buildingLevel)
        {
            BuildingLevel target = await _context.BuildingLevel.FindAsync(buildingLevel.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(buildingLevel);
                }
            }

            if (target != null)
            {
                _context.BuildingLevel.Remove(target);
                _context.Add(buildingLevel);
            }
            await _context.SaveChangesAsync();
        }

        // POST: BuildingLevel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,buildingName,buildingLevel")] BuildingLevel buildingLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingLevel);
        }

        // GET: BuildingLevel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevel = await _context.BuildingLevel.FindAsync(id);
            if (buildingLevel == null)
            {
                return NotFound();
            }
            return View(buildingLevel);
        }

        // POST: BuildingLevel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,buildingName,buildingLevel")] BuildingLevel buildingLevel)
        {
            if (id != buildingLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingLevelExists(buildingLevel.Id))
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
            return View(buildingLevel);
        }

        // GET: BuildingLevel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevel = await _context.BuildingLevel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingLevel == null)
            {
                return NotFound();
            }

            return View(buildingLevel);
        }

        // POST: BuildingLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingLevel = await _context.BuildingLevel.FindAsync(id);
            _context.BuildingLevel.Remove(buildingLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingLevelExists(int id)
        {
            return _context.BuildingLevel.Any(e => e.Id == id);
        }
    }
}
