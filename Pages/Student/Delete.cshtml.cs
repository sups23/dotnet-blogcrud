using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogCrud.Data;
using BlogCrud.Models;

namespace BlogCrud.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly BlogCrud.Data.StudContext _context;

        public DeleteModel(BlogCrud.Data.StudContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stud Stud { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stud == null)
            {
                return NotFound();
            }

            var stud = await _context.Stud.FirstOrDefaultAsync(m => m.ID == id);

            if (stud == null)
            {
                return NotFound();
            }
            else 
            {
                Stud = stud;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stud == null)
            {
                return NotFound();
            }
            var stud = await _context.Stud.FindAsync(id);

            if (stud != null)
            {
                Stud = stud;
                _context.Stud.Remove(Stud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
