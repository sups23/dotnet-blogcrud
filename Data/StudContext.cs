using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogCrud.Models;

namespace BlogCrud.Data
{
    public class StudContext : DbContext
    {
        public StudContext (DbContextOptions<StudContext> options)
            : base(options)
        {
        }

        public DbSet<BlogCrud.Models.Stud>? Stud { get; set; }
    }
}
