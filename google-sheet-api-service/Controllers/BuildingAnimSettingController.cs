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
    public class BuildingAnimSettingController : Controller
    {
        private readonly MvcBuildingAnimSettingContext _context;
        private BuildingAnimSettingLogic _logic;

        public BuildingAnimSettingController(MvcBuildingAnimSettingContext context)
        {
            _context = context;
            _logic = new BuildingAnimSettingLogic();
        }

        // GET: BuildingAnimSetting
        public async Task<IActionResult> Index()
        {
            List<BuildingAnimSetting> list = _logic.RequestBuildingAnimSettingData();
            foreach (var target in list)
            {
                await CreaetOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.BuildingAnimSetting.ToListAsync());
        }

        // GET: BuildingAnimSetting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingAnimSetting = await _context.BuildingAnimSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingAnimSetting == null)
            {
                return NotFound();
            }

            return View(buildingAnimSetting);
        }

        // GET: BuildingAnimSetting/Create
        public IActionResult Create()
        {
            return View();
        }

        public string RequestBuildingAnimSettingJson()
            => JsonConvert.SerializeObject(_logic.RequestBuildingAnimSettingData());

        private async Task CreaetOrUpdate(
            [Bind("Id,buildingSize,levelUpAnimName,checkAnimValue,levelUpAnimValue")] BuildingAnimSetting buildingAnimSetting
        )
        {
            BuildingAnimSetting target = await _context.BuildingAnimSetting.FindAsync(buildingAnimSetting.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(buildingAnimSetting);
                }
            }
            else
            {
                _context.BuildingAnimSetting.Remove(target);
                _context.Add(buildingAnimSetting);
            }

            await _context.SaveChangesAsync();
        }

        // POST: BuildingAnimSetting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,buildingSize,levelUpAnimName,checkAnimValue,levelUpAnimValue")] BuildingAnimSetting buildingAnimSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingAnimSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingAnimSetting);
        }

        // GET: BuildingAnimSetting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingAnimSetting = await _context.BuildingAnimSetting.FindAsync(id);
            if (buildingAnimSetting == null)
            {
                return NotFound();
            }
            return View(buildingAnimSetting);
        }

        // POST: BuildingAnimSetting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,buildingSize,levelUpAnimName,checkAnimValue,levelUpAnimValue")] BuildingAnimSetting buildingAnimSetting)
        {
            if (id != buildingAnimSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingAnimSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingAnimSettingExists(buildingAnimSetting.Id))
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
            return View(buildingAnimSetting);
        }

        // GET: BuildingAnimSetting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingAnimSetting = await _context.BuildingAnimSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingAnimSetting == null)
            {
                return NotFound();
            }

            return View(buildingAnimSetting);
        }

        // POST: BuildingAnimSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingAnimSetting = await _context.BuildingAnimSetting.FindAsync(id);
            _context.BuildingAnimSetting.Remove(buildingAnimSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingAnimSettingExists(int id)
        {
            return _context.BuildingAnimSetting.Any(e => e.Id == id);
        }
    }
}
