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

namespace Duplet_x_school.Pages.OptSubject
{
    public class EditModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public EditModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.OptSubject OptSubject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OptSubject = await _context.OptSubjects.FirstOrDefaultAsync(m => m.Id == id);

            if (OptSubject == null)
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

            _context.Attach(OptSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptSubjectExists(OptSubject.Id))
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

        private bool OptSubjectExists(int id)
        {
            return _context.OptSubjects.Any(e => e.Id == id);
        }
    }
}
