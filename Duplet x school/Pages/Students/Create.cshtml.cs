using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Duplet_x_school.Data;
using Duplet_x_school.Models;
using Microsoft.EntityFrameworkCore;

namespace Duplet_x_school.Pages.Students
{
    public class CreateModel : StudentsPageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public CreateModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateStudentOptSubjects(_context);
            PopulateClassesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedOptSubjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Student.StudentOptSubjectEnrollments = new List<StudentOptSubjectEnrollment>();
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            UpdateStudentOptSubjects(_context, selectedOptSubjects,  _context.Students.SingleOrDefault(c => c.IDCode == Student.IDCode));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
