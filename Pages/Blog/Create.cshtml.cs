using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogCrud.Data;
using BlogCrud.Models;

namespace BlogCrud.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly BlogCrud.Data.BlogContext _context;

        public CreateModel(BlogCrud.Data.BlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blg Blg { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Blog == null || Blg == null)
            {
                return Page();
            }

            _context.Blog.Add(Blg);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
