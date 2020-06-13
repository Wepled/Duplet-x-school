using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        [Display(Name = "Class")]
        public string Name { get; set; }
        public ICollection<StudentSchoolClassEnrollment> StudentSchoolClassEnrollments { get; set; }
        public ICollection<SchoolClassSubjectAssignment> SchoolClassSubjectAssignments { get; set; }
        public SchoolClassKabinetAssignment SchoolClassKabinetAssignment { get; set; }
        public TeacherSchoolClassAssignment TeacherSchoolClassAssignment { get; set; }

    }
}
