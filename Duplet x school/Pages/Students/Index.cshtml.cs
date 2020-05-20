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
    public class IndexModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public IndexModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(c => c.StudentOptSubjectEnrollments).ThenInclude(c=>c.OptSubject)
                .Include(c => c.StudentSchoolClassEnrollment).ThenInclude(c=>c.SchoolClass)
                .AsNoTracking()
                .ToListAsync();

        }
    }
}
