using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Grade Grade { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public string GradeInStr
        {
            get { return Subject.Name + " - " + Grade; }
        } 
    }
}
