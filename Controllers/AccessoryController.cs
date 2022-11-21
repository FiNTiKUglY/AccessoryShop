using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_053505_Pronin.Data;
using WEB_053505_Pronin.Entities;
using WEB_053505_Pronin.Models;
using WEB_053505_Pronin.ExtestionMethods;

namespace WEB_053505_Pronin.Controllers
{
    public class AccessoryController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger _logger;
        private readonly int _pageSize = 3;

        public AccessoryController(AppDBContext context, ILogger<AccessoryController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public async Task<IActionResult> Index(int? category, int pageNo = 1)
		{
            var list = _context.Accessory;
            ViewData["Categories"] = _context.AccessoryCategory.ToList();
            ViewData["CurrentCategory"] = category ?? 0;
            if (category == 0) category = null;
            var items = ListViewModel<Accessory>.GetModel(list, pageNo, _pageSize, g => !category.HasValue || g.CategoryId == category.Value);

            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial", items);
            else
                return View(items);
        }

        // GET: Accessory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accessory == null)
            {
                return NotFound();
            }

            var accessory = await _context.Accessory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessory == null)
            {
                return NotFound();
            }

            return View(accessory);
        }

        // GET: Accessory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accessory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Category,CategoryId,Cost,Image")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessory);
        }

        // GET: Accessory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accessory == null)
            {
                return NotFound();
            }

            var accessory = await _context.Accessory.FindAsync(id);
            if (accessory == null)
            {
                return NotFound();
            }
            return View(accessory);
        }

        // POST: Accessory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Category,CategoryId,Cost,Image")] Accessory accessory)
        {
            if (id != accessory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoryExists(accessory.Id))
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
            return View(accessory);
        }

        // GET: Accessory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accessory == null)
            {
                return NotFound();
            }

            var accessory = await _context.Accessory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessory == null)
            {
                return NotFound();
            }

            return View(accessory);
        }

        // POST: Accessory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accessory == null)
            {
                return Problem("Entity set 'AppDBContext.Accessory'  is null.");
            }
            var accessory = await _context.Accessory.FindAsync(id);
            if (accessory != null)
            {
                _context.Accessory.Remove(accessory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoryExists(int id)
        {
            return _context.Accessory.Any(e => e.Id == id);
        }
    }
}
