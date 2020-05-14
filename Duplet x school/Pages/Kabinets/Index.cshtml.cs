using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.Kabinets
{
    public class IndexModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public IndexModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Kabinet> Kabinet { get;set; }

        public async Task OnGetAsync()
        {
            Kabinet = await _context.Kabinets.ToListAsync();
        }
    }
}
