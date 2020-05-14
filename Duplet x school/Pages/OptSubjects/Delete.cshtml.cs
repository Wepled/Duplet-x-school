using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.OptSubjects
{
    public class DeleteModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public DeleteModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OptSubject OptSubject { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OptSubject = await _context.OptSubjects.FindAsync(id);

            if (OptSubject != null)
            {
                _context.OptSubjects.Remove(OptSubject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
