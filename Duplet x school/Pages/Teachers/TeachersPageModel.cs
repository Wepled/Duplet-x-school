using Duplet_x_school.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Pages.Teachers
{
    public class TeachersPageModel : PageModel
    {
        public SelectList SchoolClassNameSL { get; set; }

        public void PopulateClassesDropDownList(SchoolContext _context,
            object selectedSchoolClass = null)
        {
            var classesQuery = from d in _context.SchoolClasses
                                   orderby d.Name // Sort by name.
                                   select d;

            SchoolClassNameSL = new SelectList(classesQuery.AsNoTracking(),
                        "Id", "Name", selectedSchoolClass);
        }
    }
}
