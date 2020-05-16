using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Duplet_x_school.Models
{
    public class StudentSchoolClassEnrollment
    {
        public int StudentSchoolClassEnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SchoolClassId { get; set; }
        public Student Student { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}
