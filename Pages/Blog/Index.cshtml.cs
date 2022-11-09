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
    public class IndexModel : PageModel
    {
        private readonly BlogCrud.Data.BlogContext _context;

        public IndexModel(BlogCrud.Data.BlogContext context)
        {
            _context = context;
        }

        public IList<Blg> Blg { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Blog != null)
            {
                Blg = await _context.Blog.ToListAsync();
            }
        }
    }
}
