using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Models;

namespace Duplet_x_school.Data
{
    public class Duplet_x_schoolContext : DbContext
    {
        public Duplet_x_schoolContext (DbContextOptions<Duplet_x_schoolContext> options)
            : base(options)
        {
        }

        public DbSet<Duplet_x_school.Models.Class> Class { get; set; }
    }
}
