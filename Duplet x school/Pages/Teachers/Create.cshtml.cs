using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Duplet_x_school.Models;
using Duplet_x_school.Data;
using System.Collections.Generic;

namespace Duplet_x_school.Pages.Teachers
{
    public class CreateModel : TeachersPageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateClassesDropDownList(_context);
            PopulateTeacherSubjects(_context);
            return Page();
        }


        [BindProperty]
        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedSubjects)
        {
            var emptyTeacher = new Teacher();

            if (await TryUpdateModelAsync<Teacher>(
                 emptyTeacher,
                 "teacher",   // Prefix for form value.
                 s => s.Id, s => s.FirstMidName, s => s.LastName, s => s.HireDate, s => s.TeacherKabinetAssignment, s => s.TeacherSubjectAssignments, s => s.TeacherOptSubjectAssignments, s => s.TeacherSchoolClassAssignment))
            {
                emptyTeacher.TeacherSubjectAssignments = new List<TeacherSubjectAssignment>();
                _context.Teachers.Add(emptyTeacher);
                await _context.SaveChangesAsync();
                UpdateTeacherSubjects(_context, selectedSubjects, emptyTeacher);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateClassesDropDownList(_context, emptyTeacher.TeacherSchoolClassAssignment.SchoolClassId);
            return Page();
        }
    }
}
