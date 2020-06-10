using Duplet_x_school.Data;
using Duplet_x_school.Models;
using Duplet_x_school.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Duplet_x_school.Pages.Teachers
{
    public class TeachersPageModel : PageModel
    {
        public SelectList SchoolClassNameSL { get; set; }

        public List<AssignedSubjectData> AssignedSubjectDataList;

        public void PopulateClassesDropDownList(SchoolContext _context,
            object selectedSchoolClass = null)
        {
            var classesQuery = from d in _context.SchoolClasses
                                   orderby d.Name // Sort by name.
                                   select d;

            SchoolClassNameSL = new SelectList(classesQuery.AsNoTracking(),
                        "Id", "Name", selectedSchoolClass);
        }

        public void PopulateTeacherSubjects(SchoolContext context,
                                                Teacher teacher = null)
        {
            var allSubjects = context.Subjects;
            var teacherSubjects = new HashSet<int>();
            if (teacher != null)
            {
                teacherSubjects = new HashSet<int>(
                   teacher.TeacherSubjectAssignments.Select(c => c.SubjectId));
            }
            AssignedSubjectDataList = new List<AssignedSubjectData>();
            foreach (var subject in allSubjects)
            {
                AssignedSubjectDataList.Add(new AssignedSubjectData
                {
                    SubjectId = subject.Id,
                    Title = subject.Name,
                    Assigned = teacherSubjects.Contains(subject.Id)
                });
            }
        }

        public void UpdateTeacherSubjects(SchoolContext context,
            string[] selectedSubjects, Teacher teacherToUpdate = null)
        {

            if (selectedSubjects == null)
            {
                teacherToUpdate.TeacherSubjectAssignments = new List<TeacherSubjectAssignment>();
                return;
            }

            var selectedSubjectsHS = new HashSet<string>(selectedSubjects);
            var teacherSubjects = new HashSet<int>();
            if (teacherToUpdate.TeacherSubjectAssignments != null)
            {
                teacherSubjects = new HashSet<int>
                    (teacherToUpdate.TeacherSubjectAssignments.Select(c => c.Subject.Id));
            }
            foreach (var subject in context.Subjects)
            {
                if (selectedSubjectsHS.Contains(subject.Id.ToString()))
                {
                    if (!teacherSubjects.Contains(subject.Id))
                    {
                        teacherToUpdate.TeacherSubjectAssignments.Add(
                            new TeacherSubjectAssignment
                            {
                                TeacherId = teacherToUpdate.Id,
                                SubjectId = subject.Id
                            });
                    }
                }
                else
                {
                    if (teacherSubjects.Contains(subject.Id))
                    {
                        TeacherSubjectAssignment SubjectToRemove
                            = teacherToUpdate
                                .TeacherSubjectAssignments
                                .SingleOrDefault(i => i.SubjectId == subject.Id);
                        context.Remove(SubjectToRemove);
                    }
                }
            }
        }
    }
}
