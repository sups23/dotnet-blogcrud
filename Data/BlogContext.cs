using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogCrud.Models;

namespace BlogCrud.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<BlogCrud.Models.Blg>? Blog { get; set; }
    }
}
