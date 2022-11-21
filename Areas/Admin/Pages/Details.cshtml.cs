using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053505_Pronin.Data;
using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_053505_Pronin.Data.AppDBContext _context;

        public DetailsModel(WEB_053505_Pronin.Data.AppDBContext context)
        {
            _context = context;
        }

      public Accessory Accessory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accessory == null)
            {
                return NotFound();
            }

            var accessory = await _context.Accessory.FirstOrDefaultAsync(m => m.Id == id);
            if (accessory == null)
            {
                return NotFound();
            }
            else 
            {
                Accessory = accessory;
            }
            return Page();
        }
    }
}
