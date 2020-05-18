using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class TeacherOptSubjectAssignment
    {
        public int TeacherId { get; set; }
        public int OptSubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public OptSubject OptSubject { get; set; }

    }
}
