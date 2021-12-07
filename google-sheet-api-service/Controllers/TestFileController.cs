using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

namespace google_sheet_api_service.Controllers
{
    public class TestFileController : Controller
    {
        private readonly MvcTestFileContext _context;

        public TestFileController(MvcTestFileContext context)
        {
            _context = context;
        }

        // GET: TestFile
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestFile.ToListAsync());
        }

        // GET: TestFile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFile = await _context.TestFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testFile == null)
            {
                return NotFound();
            }

            return View(testFile);
        }

        // GET: TestFile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestFile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Test1,Test2,Test3,Test4,Test5")] TestFile testFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testFile);
        }

        // GET: TestFile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFile = await _context.TestFile.FindAsync(id);
            if (testFile == null)
            {
                return NotFound();
            }
            return View(testFile);
        }

        // POST: TestFile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Test1,Test2,Test3,Test4,Test5")] TestFile testFile)
        {
            if (id != testFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestFileExists(testFile.Id))
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
            return View(testFile);
        }

        // GET: TestFile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFile = await _context.TestFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testFile == null)
            {
                return NotFound();
            }

            return View(testFile);
        }

        // POST: TestFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testFile = await _context.TestFile.FindAsync(id);
            _context.TestFile.Remove(testFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestFileExists(int id)
        {
            return _context.TestFile.Any(e => e.Id == id);
        }
    }
}
