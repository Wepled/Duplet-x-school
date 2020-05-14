using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duplet_x_school.Models
{
    public class SubjectAssignment
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int SchoolClassId { get; set; }
    }
}
