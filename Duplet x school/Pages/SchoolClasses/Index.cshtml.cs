using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.SchoolClasses
{
    public class IndexModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public IndexModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<SchoolClass> SchoolClasses { get;set; }
        public SchoolClass SchoolClassStudents { get;set; }
        public int? SchoolClassID { get; set; }

        public async Task OnGetAsync(int? Id)
        {
            SchoolClasses = await _context.SchoolClasses
                .Include(c => c.StudentSchoolClassEnrollments)
                .Include(c => c.SchoolClassKabinetAssignment).ThenInclude(c=>c.Kabinet)
                .Include(c => c.TeacherSchoolClassAssignment).ThenInclude(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync(); ;

            if (Id != null)
            {
                SchoolClassID = Id.Value;

                SchoolClassStudents = await _context.SchoolClasses
                    .Include(c => c.StudentSchoolClassEnrollments).ThenInclude(c => c.Student)
                    .FirstOrDefaultAsync(c => c.Id == SchoolClassID);
            }
            
        }
    }
}
