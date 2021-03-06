﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public DeleteModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kabinet Kabinet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kabinet = await _context.Kabinets.FirstOrDefaultAsync(m => m.Id == id);

            if (Kabinet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kabinet = await _context.Kabinets.FindAsync(id);

            if (Kabinet != null)
            {
                _context.Kabinets.Remove(Kabinet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
