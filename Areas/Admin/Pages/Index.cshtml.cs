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
    public class IndexModel : PageModel
    {
        private readonly WEB_053505_Pronin.Data.AppDBContext _context;

        public IndexModel(WEB_053505_Pronin.Data.AppDBContext context)
        {
            _context = context;
        }

        public IList<Accessory> Accessory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accessory != null)
            {
                Accessory = await _context.Accessory.ToListAsync();
            }
        }
    }
}
