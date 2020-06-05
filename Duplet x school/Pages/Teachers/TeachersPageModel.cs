using Duplet_x_school.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Pages.Teachers
{
    public class TeachersPageModel
    {
        public SelectList ClassNameSL { get; set; }

        public void PopulateClassesDropDownList(SchoolContext _context,
            object selectedClass = null)
        {
            var classesQuery = from d in _context.SchoolClasses
                                   orderby d.Name // Sort by name.
                                   select d;

            ClassNameSL = new SelectList(classesQuery.AsNoTracking(),
                        "DepartmentID", "Name", selectedClass);
        }
    }
}
