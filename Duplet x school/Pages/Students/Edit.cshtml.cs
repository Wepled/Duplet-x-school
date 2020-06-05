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

namespace Duplet_x_school.Pages.Students
{
    public class EditModel : StudentsPageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public EditModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(c => c.StudentOptSubjectEnrollments).ThenInclude(c => c.OptSubject)
                .Include(c => c.StudentSchoolClassEnrollment).ThenInclude(c => c.SchoolClass)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);


            if (Student == null)
            {
                return NotFound();
            }
            PopulateStudentOptSubjects(_context, Student);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id, string[] selectedOptSubjects)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Students
                .Include(c => c.StudentOptSubjectEnrollments).ThenInclude(c => c.OptSubject)
                .Include(c => c.StudentSchoolClassEnrollment).ThenInclude(c => c.SchoolClass)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "Student",
                i => i.FirstMidName, i => i.LastName,
                i => i.IDCode, i => i.StudentOptSubjectEnrollments))
            {
                if (String.IsNullOrWhiteSpace(
                    studentToUpdate.StudentOptSubjectEnrollments.ToString()))
                {
                    studentToUpdate.StudentOptSubjectEnrollments = null;
                }
                UpdateInstructorCourses(_context, selectedOptSubjects, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateInstructorCourses(_context, selectedOptSubjects, studentToUpdate);
            PopulateStudentOptSubjects(_context, studentToUpdate);

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
