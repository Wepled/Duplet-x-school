using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class SchoolClassKabinetAssignment
    {
        public int SchoolClassKabinetAssignmentId { get; set; }
        public int SchoolClassId { get; set; }
        public int KabinetId { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public Kabinet Kabinet { get; set; }
        
    }
}
