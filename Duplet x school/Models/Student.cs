using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duplet_x_school.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]

        [StringLength(50)]

        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]

        [Column("FirstName")]

        [Display(Name = "First Name")]

        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]

        public string FullName

        {

            get

            {

                return LastName + ", " + FirstMidName;

            }

        }
        [Display(Name = "ID code")]
        public string IDCode { get; set; }
        public StudentSchoolClassEnrollment StudentSchoolClassEnrollment { get; set; }
        public ICollection<StudentOptSubjectEnrollment> StudentOptSubjectEnrollments { get; set; }
        public ICollection<Grades> StudentGradeses { get; set; }
    }
}
