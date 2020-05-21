using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public DetailsModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.StudentOptSubjectEnrollments)
                    .ThenInclude(e => e.OptSubject)
                .Include(s => s.StudentSchoolClassEnrollment)
                    .ThenInclude(e => e.SchoolClass)
                .Include(s => s.StudentGradeses)
                    .ThenInclude(e => e.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
