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

namespace Duplet_x_school.Pages.SchoolClasses
{
    public class EditModel : SchoolClassPAgemodel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public EditModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolClass SchoolClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolClass = await _context.SchoolClasses
                .Include(m=>m.SchoolClassSubjectAssignments).ThenInclude(m=>m.Subject)
                .Include(m=>m.SchoolClassKabinetAssignment).ThenInclude(m=>m.Kabinet)
                .Include(c => c.TeacherSchoolClassAssignment)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (SchoolClass == null)
            {
                return NotFound();
            }
            PopulateKabinetsDropDownList(_context, SchoolClass);
            PopulateClassSubjects(_context, SchoolClass);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id, string[] selectedSubjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var schoolClassToUpdate = await _context.SchoolClasses
                .Include(c => c.SchoolClassSubjectAssignments).ThenInclude(c => c.Subject)
                .Include(c => c.SchoolClassKabinetAssignment).ThenInclude(c => c.Kabinet)
                .Include(c => c.TeacherSchoolClassAssignment).ThenInclude(c=> c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == SchoolClass.Id);

            if (await TryUpdateModelAsync<SchoolClass>(
                schoolClassToUpdate,
                "SchoolClass",
                i => i.Name, i => i.SchoolClassSubjectAssignments,
                i => i.StudentSchoolClassEnrollments,
                i => i.TeacherSchoolClassAssignment))
            {
                if (String.IsNullOrWhiteSpace(
                    schoolClassToUpdate.SchoolClassSubjectAssignments.ToString()))
                {
                    schoolClassToUpdate.SchoolClassSubjectAssignments = null;
                }

                UpdateClassSubjects(_context, selectedSubjects, schoolClassToUpdate);
                UpdateKabinets(_context, SchoolClass.SchoolClassKabinetAssignment.KabinetId, schoolClassToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateKabinetsDropDownList(_context, SchoolClass);
            PopulateClassSubjects(_context, schoolClassToUpdate);
            return RedirectToPage("./Index");
        }

        private bool SchoolClassExists(int id)
        {
            return _context.SchoolClasses.Any(e => e.Id == id);
        }
    }
}
