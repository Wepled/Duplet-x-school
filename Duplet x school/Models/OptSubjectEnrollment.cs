using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class OptSubjectEnrollment
    {
        public int OptSubjectEnrollmentId { get; set; }
        public int OptSubjectId { get; set; }
        public int StudentId { get; set; }

        public OptSubject OptSubject { get; set; }
        public Student Student { get; set; }
    }
}
