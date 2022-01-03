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
    public class BuildingLevelSizeController : Controller
    {
        private readonly MvcBuildingLevelSizeContext _context;
        private BuildingLevelSizeLogic _logic;

        public BuildingLevelSizeController(MvcBuildingLevelSizeContext context)
        {
            _context = context;
            _logic = new BuildingLevelSizeLogic();
        }

        // GET: BuildingLevelSize
        public async Task<IActionResult> Index()
        {
            List<BuildingLevelSize> list = _logic.RequestBuildingLevelSizeData();
            foreach (BuildingLevelSize target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update :{JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.BuildingLevelSize.ToListAsync());
        }

        // GET: BuildingLevelSize/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevelSize = await _context.BuildingLevelSize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingLevelSize == null)
            {
                return NotFound();
            }

            return View(buildingLevelSize);
        }

        private async Task CreateOrUpdate(
            [Bind("Id,buildingName,buildingLevel,islandGid,buildingGid,checkAnim,levelUpAnim,buildingSize")] BuildingLevelSize buildingLevelSize
        )
        {
            BuildingLevelSize target = await _context.BuildingLevelSize.FindAsync(buildingLevelSize.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(buildingLevelSize);
                }
            }

            if (target != null)
            {
                _context.BuildingLevelSize.Remove(target);
                _context.Add(buildingLevelSize);
            }

            await _context.SaveChangesAsync();
        }

        // GET: BuildingLevelSize/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingLevelSize/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,buildingName,buildingLevel,islandGid,buildingGid,checkAnim,levelUpAnim,buildingSize")] BuildingLevelSize buildingLevelSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingLevelSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingLevelSize);
        }

        // GET: BuildingLevelSize/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevelSize = await _context.BuildingLevelSize.FindAsync(id);
            if (buildingLevelSize == null)
            {
                return NotFound();
            }
            return View(buildingLevelSize);
        }

        // POST: BuildingLevelSize/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,buildingName,buildingLevel,islandGid,buildingGid,checkAnim,levelUpAnim,buildingSize")] BuildingLevelSize buildingLevelSize)
        {
            if (id != buildingLevelSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingLevelSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingLevelSizeExists(buildingLevelSize.Id))
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
            return View(buildingLevelSize);
        }

        // GET: BuildingLevelSize/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingLevelSize = await _context.BuildingLevelSize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingLevelSize == null)
            {
                return NotFound();
            }

            return View(buildingLevelSize);
        }

        // POST: BuildingLevelSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingLevelSize = await _context.BuildingLevelSize.FindAsync(id);
            _context.BuildingLevelSize.Remove(buildingLevelSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingLevelSizeExists(int id)
        {
            return _context.BuildingLevelSize.Any(e => e.Id == id);
        }
    }
}
