using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogCrud.Data;
using BlogCrud.Models;

namespace BlogCrud.Pages.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly BlogCrud.Data.BlogContext _context;

        public DeleteModel(BlogCrud.Data.BlogContext context)
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

            var blg = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);

            if (blg == null)
            {
                return NotFound();
            }
            else 
            {
                Blg = blg;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }
            var blg = await _context.Blog.FindAsync(id);

            if (blg != null)
            {
                Blg = blg;
                _context.Blog.Remove(Blg);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
