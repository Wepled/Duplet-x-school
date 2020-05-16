using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Duplet_x_school.Models
{
    public class SchoolClassSubjectAssignment
    {
        public int SchoolClassId { get; set; }
        public int SubjectId { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public Subject Subject { get; set; }

    }
}
