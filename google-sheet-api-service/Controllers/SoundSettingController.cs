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
    public class SoundSettingController : Controller
    {
        private readonly MvcSoundSettingContext _context;
        private SoundSettingLogic _logic;

        public SoundSettingController(MvcSoundSettingContext context)
        {
            _context = context;
            _logic = new SoundSettingLogic();
        }

        // GET: SoundSetting
        public async Task<IActionResult> Index()
        {
            var list = _logic.RequestSoundSettingData();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.SoundSetting.ToListAsync());
        }

        // GET: SoundSetting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundSetting = await _context.SoundSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundSetting == null)
            {
                return NotFound();
            }

            return View(soundSetting);
        }

        public string RequestSoundSettingJson()
            => JsonConvert.SerializeObject(_logic.RequestSoundSettingData());

        // GET: SoundSetting/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,islandGid,islandName,bgmVolume,windVolume,waveVolume,birdVolume,lakeVolume,bellVolume")] SoundSetting soundSetting
        )
        {
            var target = await _context.SoundSetting.FindAsync(soundSetting.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(soundSetting);
                }
            }
            else
            {
                _context.SoundSetting.Remove(target);
                _context.Add(soundSetting);
            }

            await _context.SaveChangesAsync();
        }

        // POST: SoundSetting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,islandGid,islandName,bgmVolume,windVolume,waveVolume,birdVolume,lakeVolume,bellVolume")] SoundSetting soundSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soundSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soundSetting);
        }

        // GET: SoundSetting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundSetting = await _context.SoundSetting.FindAsync(id);
            if (soundSetting == null)
            {
                return NotFound();
            }
            return View(soundSetting);
        }

        // POST: SoundSetting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,islandGid,islandName,bgmVolume,windVolume,waveVolume,birdVolume,lakeVolume,bellVolume")] SoundSetting soundSetting)
        {
            if (id != soundSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soundSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoundSettingExists(soundSetting.Id))
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
            return View(soundSetting);
        }

        // GET: SoundSetting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundSetting = await _context.SoundSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundSetting == null)
            {
                return NotFound();
            }

            return View(soundSetting);
        }

        // POST: SoundSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soundSetting = await _context.SoundSetting.FindAsync(id);
            _context.SoundSetting.Remove(soundSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoundSettingExists(int id)
        {
            return _context.SoundSetting.Any(e => e.Id == id);
        }
    }
}
