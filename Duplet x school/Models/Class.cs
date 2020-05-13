using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public int KabinetID { get; set; }
        public int TeacherID { get; set; }

    }
}
