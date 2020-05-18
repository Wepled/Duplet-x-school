using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName

        {

            get { return LastName + ", " + FirstMidName; }

        }
        public ICollection<TeacherSubjectAssignment> TeacherSubjectAssignments { get; set; }
        public ICollection<TeacherOptSubjectAssignment> TeacherOptSubjectAssignments { get; set; }
        public TeacherSchoolClassAssignment TeacherSchoolClassAssignment { get; set; }
        public TeacherKabinetAssignment TeacherKabinetAssignment { get; set; }
    }
}
