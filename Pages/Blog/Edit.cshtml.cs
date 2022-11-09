using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogCrud.Data;
using BlogCrud.Models;

namespace BlogCrud.Pages.Blog
{
    public class EditModel : PageModel
    {
        private readonly BlogCrud.Data.BlogContext _context;

        public EditModel(BlogCrud.Data.BlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blg Blg { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blg =  await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
            if (blg == null)
            {
                return NotFound();
            }
            Blg = blg;
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

            _context.Attach(Blg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlgExists(Blg.ID))
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

        private bool BlgExists(int id)
        {
          return (_context.Blog?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
