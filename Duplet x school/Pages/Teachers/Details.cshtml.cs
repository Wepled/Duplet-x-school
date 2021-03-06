﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public DetailsModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher = await _context.Teachers
                .Include(s => s.TeacherKabinetAssignment)
                    .ThenInclude(e => e.Kabinet)
                .Include(s => s.TeacherOptSubjectAssignments)
                    .ThenInclude(e => e.OptSubject)
                .Include(s => s.TeacherSchoolClassAssignment)
                    .ThenInclude(e => e.SchoolClass)
                .Include(s => s.TeacherSubjectAssignments)
                    .ThenInclude(e => e.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
