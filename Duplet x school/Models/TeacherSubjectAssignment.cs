using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class TeacherSubjectAssignment
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }

    }
}
