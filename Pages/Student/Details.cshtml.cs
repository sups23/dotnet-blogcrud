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
    public class DetailsModel : PageModel
    {
        private readonly BlogCrud.Data.StudContext _context;

        public DetailsModel(BlogCrud.Data.StudContext context)
        {
            _context = context;
        }

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
    }
}
