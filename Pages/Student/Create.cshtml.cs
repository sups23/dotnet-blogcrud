using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogCrud.Data;
using BlogCrud.Models;

namespace BlogCrud.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly BlogCrud.Data.StudContext _context;

        public CreateModel(BlogCrud.Data.StudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stud Stud { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stud == null || Stud == null)
            {
                return Page();
            }

            _context.Stud.Add(Stud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
