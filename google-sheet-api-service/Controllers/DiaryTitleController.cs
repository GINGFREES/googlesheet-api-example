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
    public class DiaryTitleController : Controller
    {
        private readonly MvcDiaryTitleContext _context;
        private DiaryTitleLogic _logic;

        public DiaryTitleController(MvcDiaryTitleContext context)
        {
            _context = context;
            _logic = new DiaryTitleLogic();
        }

        // GET: DiaryTitle
        public async Task<IActionResult> Index()
        {
            List<DiaryTitle> list = _logic.RequestDiaryTitleData();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.DiaryTitle.ToListAsync());
        }

        // GET: DiaryTitle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryTitle = await _context.DiaryTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaryTitle == null)
            {
                return NotFound();
            }

            return View(diaryTitle);
        }

        // GET: DiaryTitle/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task CreateOrUpdate(
            [Bind("Id,diaryTitleName,diaryTitleKey")] DiaryTitle diaryTitle
        )
        {
            DiaryTitle target = await _context.DiaryTitle.FindAsync(diaryTitle.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(diaryTitle);
                }
            }
            else
            {
                _context.DiaryTitle.Remove(target);
                _context.Add(diaryTitle);
            }

            await _context.SaveChangesAsync();
        }

        // POST: DiaryTitle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,diaryTitleName,diaryTitleKey")] DiaryTitle diaryTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaryTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaryTitle);
        }

        // GET: DiaryTitle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryTitle = await _context.DiaryTitle.FindAsync(id);
            if (diaryTitle == null)
            {
                return NotFound();
            }
            return View(diaryTitle);
        }

        // POST: DiaryTitle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,diaryTitleName,diaryTitleKey")] DiaryTitle diaryTitle)
        {
            if (id != diaryTitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaryTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryTitleExists(diaryTitle.Id))
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
            return View(diaryTitle);
        }

        // GET: DiaryTitle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaryTitle = await _context.DiaryTitle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaryTitle == null)
            {
                return NotFound();
            }

            return View(diaryTitle);
        }

        // POST: DiaryTitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaryTitle = await _context.DiaryTitle.FindAsync(id);
            _context.DiaryTitle.Remove(diaryTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaryTitleExists(int id)
        {
            return _context.DiaryTitle.Any(e => e.Id == id);
        }
    }
}
