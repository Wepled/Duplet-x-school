﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.SchoolClass
{
    public class DetailsModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public DetailsModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public Models.SchoolClass SchoolClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolClass = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);

            if (SchoolClass == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
