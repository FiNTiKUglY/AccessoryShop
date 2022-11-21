using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using WEB_053505_Pronin.Data;
using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_053505_Pronin.Data.AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(WEB_053505_Pronin.Data.AppDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            ViewData["Categories"] = new SelectList(_context.AccessoryCategory, "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Accessory Accessory { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Accessory.Category = _context.AccessoryCategory.Find(Accessory.CategoryId).CategoryName;
            Accessory.Image = "default.jpg";
            if (Image != null)
            {
                _context.Accessory.Add(Accessory);
                var newId = _context.Accessory.OrderBy(item => item.Id).Last().Id;
                var fileName = $"{newId}.jpg";
                Accessory.Image = fileName;
                var path = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                return Page();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
