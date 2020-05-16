using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class TeacherSchoolClassAssignment
    {
        public int TeacherId { get; set; }
        public int SchoolClassId { get; set; }
        public Teacher Teacher { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}
