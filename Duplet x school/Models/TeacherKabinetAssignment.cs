using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class TeacherKabinetAssignment
    {
        public int TeacherId { get; set; }
        public int KabinetId { get; set; }
        public Kabinet Kabinet { get; set; }
        public Teacher Teacher { get; set; }

    }
}
