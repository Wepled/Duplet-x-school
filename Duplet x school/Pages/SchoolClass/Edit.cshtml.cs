using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.SchoolClass
{
    public class EditModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public EditModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SchoolClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolClassExists(SchoolClass.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchoolClassExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
