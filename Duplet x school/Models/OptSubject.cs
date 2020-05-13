using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class OptSubject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int StudentID { get; set; }
        public int TeacherID { get; set; }
    }
}
