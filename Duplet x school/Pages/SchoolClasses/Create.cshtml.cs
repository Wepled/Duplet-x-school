﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Duplet_x_school.Data;
using Duplet_x_school.Models;

namespace Duplet_x_school.Pages.SchoolClasses
{
    public class CreateModel : SchoolClassPAgemodel
    {
        private readonly Duplet_x_school.Data.SchoolContext _context;

        public CreateModel(Duplet_x_school.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateClassSubjects(_context);
            return Page();
        }

        [BindProperty]
        public SchoolClass SchoolClass { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedSubjects)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UpdateClassSubjects(_context, selectedSubjects, SchoolClass);
            _context.SchoolClasses.Add(SchoolClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
