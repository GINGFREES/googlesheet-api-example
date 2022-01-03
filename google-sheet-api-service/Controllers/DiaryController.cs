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
    public class DiaryController : Controller
    {
        private readonly MvcDiaryContext _context;
        private DiaryLogic _logic;

        public DiaryController(MvcDiaryContext context)
        {
            _context = context;
            _logic = new DiaryLogic();
        }

        // GET: Diary
        public async Task<IActionResult> Index()
        {
            List<Diary> list = _logic.RequestDiaryData();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.Diary.ToListAsync());
        }

        // GET: Diary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // GET: Diary/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,gId,name,characterGid,characterName,diaryTitleKey,diaryContentKey")] Diary diary
        )
        {
            Diary target = await _context.Diary.FindAsync(diary.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(diary);
                }
            }
            else
            {
                _context.Diary.Remove(target);
                _context.Add(diary);
            }

            await _context.SaveChangesAsync();
        }

        // POST: Diary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,gId,name,characterGid,characterName,diaryTitleKey,diaryContentKey")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diary);
        }

        // GET: Diary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }
            return View(diary);
        }

        // POST: Diary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,gId,name,characterGid,characterName,diaryTitleKey,diaryContentKey")] Diary diary)
        {
            if (id != diary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryExists(diary.Id))
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
            return View(diary);
        }

        // GET: Diary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // POST: Diary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diary = await _context.Diary.FindAsync(id);
            _context.Diary.Remove(diary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaryExists(int id)
        {
            return _context.Diary.Any(e => e.Id == id);
        }
    }
}
