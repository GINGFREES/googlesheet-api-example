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
    public class StoryDialogueController : Controller
    {
        private readonly MvcStoryDialogueContext _context;
        private StoryDialogueLogic _logic;

        public StoryDialogueController(MvcStoryDialogueContext context)
        {
            _context = context;
            _logic = new StoryDialogueLogic();
        }

        // GET: StoryDialogue
        public async Task<IActionResult> Index()
        {
            List<StoryDialogue> list = _logic.RequestStoryDialogueData();
            foreach (var target in list)
            {
                await CreateOrUpdate(target);
                Console.WriteLine($"Create or update {JsonConvert.SerializeObject(target)}");
            }
            return View(await _context.StoryDialogue.ToListAsync());
        }

        // GET: StoryDialogue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyDialogue = await _context.StoryDialogue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storyDialogue == null)
            {
                return NotFound();
            }

            return View(storyDialogue);
        }

        // GET: StoryDialogue/Create
        public IActionResult Create()
        {
            return View();
        }

        public string RequestStoryDialogueJson()
            => JsonConvert.SerializeObject(_logic.RequestStoryDialogueData());

        private async Task CreateOrUpdate(
            [Bind("Id,storyName,stroyGid,characterName,dialogueSortIndex,content,contentKey,optionDialogue01,optionDialogue02,optionDialogue01Key,optionDialogue02Key")] StoryDialogue storyDialogue
        )
        {
            StoryDialogue target = await _context.StoryDialogue.FindAsync(storyDialogue.Id);
            if (target == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(storyDialogue);
                }
            }
            else
            {
                _context.StoryDialogue.Remove(target);
                _context.Add(storyDialogue);
            }
            await _context.SaveChangesAsync();

        }

        // POST: StoryDialogue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,storyName,stroyGid,characterName,dialogueSortIndex,content,contentKey,optionDialogue01,optionDialogue02,optionDialogue01Key,optionDialogue02Key")] StoryDialogue storyDialogue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storyDialogue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storyDialogue);
        }

        // GET: StoryDialogue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyDialogue = await _context.StoryDialogue.FindAsync(id);
            if (storyDialogue == null)
            {
                return NotFound();
            }
            return View(storyDialogue);
        }

        // POST: StoryDialogue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,storyName,stroyGid,characterName,dialogueSortIndex,content,contentKey,optionDialogue01,optionDialogue02,optionDialogue01Key,optionDialogue02Key")] StoryDialogue storyDialogue)
        {
            if (id != storyDialogue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storyDialogue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryDialogueExists(storyDialogue.Id))
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
            return View(storyDialogue);
        }

        // GET: StoryDialogue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyDialogue = await _context.StoryDialogue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storyDialogue == null)
            {
                return NotFound();
            }

            return View(storyDialogue);
        }

        // POST: StoryDialogue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storyDialogue = await _context.StoryDialogue.FindAsync(id);
            _context.StoryDialogue.Remove(storyDialogue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryDialogueExists(int id)
        {
            return _context.StoryDialogue.Any(e => e.Id == id);
        }
    }
}
