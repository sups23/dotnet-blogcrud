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

namespace BlogCrud.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly BlogCrud.Data.StudContext _context;

        public EditModel(BlogCrud.Data.StudContext context)
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

            var stud =  await _context.Stud.FirstOrDefaultAsync(m => m.ID == id);
            if (stud == null)
            {
                return NotFound();
            }
            Stud = stud;
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

            _context.Attach(Stud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudExists(Stud.ID))
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

        private bool StudExists(int id)
        {
          return (_context.Stud?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
