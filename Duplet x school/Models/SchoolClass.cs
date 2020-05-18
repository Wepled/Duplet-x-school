using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentSchoolClassEnrollment> StudentSchoolClassEnrollment { get; set; }

    }
}
