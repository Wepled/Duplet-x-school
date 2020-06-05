using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.Teachers
{
    public class CreateModel : TeachersPageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public CreateModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateClassesDropDownList(_context);
            return Page();
        }


        [BindProperty]
        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTeacher = new Teacher();

            if (await TryUpdateModelAsync<Teacher>(
                 emptyTeacher,
                 "teacher",   // Prefix for form value.
                 s => s.Id, s => s.FirstMidName, s => s.LastName, s => s.HireDate, s => s.TeacherKabinetAssignment, s => s.TeacherSubjectAssignments, s => s.TeacherOptSubjectAssignments, s => s.TeacherSchoolClassAssignment))
            {
                _context.Teachers.Add(emptyTeacher);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateClassesDropDownList(_context, emptyTeacher.TeacherSchoolClassAssignment.SchoolClassId);
            return Page();
        }
    }
}
