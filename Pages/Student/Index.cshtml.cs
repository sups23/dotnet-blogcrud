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
    public class IndexModel : PageModel
    {
        private readonly BlogCrud.Data.StudContext _context;

        public IndexModel(BlogCrud.Data.StudContext context)
        {
            _context = context;
        }

        public IList<Stud> Stud { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stud != null)
            {
                Stud = await _context.Stud.ToListAsync();
            }
        }
    }
}
