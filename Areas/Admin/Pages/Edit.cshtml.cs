using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_053505_Pronin.Data;
using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WEB_053505_Pronin.Data.AppDBContext _context;

        public EditModel(WEB_053505_Pronin.Data.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Accessory Accessory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accessory == null)
            {
                return NotFound();
            }

            var accessory =  await _context.Accessory.FirstOrDefaultAsync(m => m.Id == id);
            if (accessory == null)
            {
                return NotFound();
            }
            Accessory = accessory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Accessory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoryExists(Accessory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccessoryExists(int id)
        {
          return _context.Accessory.Any(e => e.Id == id);
        }
    }
}
