using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duplet_x_school.Data;
using Duplet_x_school.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Duplet_x_school.Pages.Students
{
    public class StudentsPageModel : PageModel
    {

        public List<AssignedOptSubjectData> AssignedOptSubjectDataList;
        public SelectList SchoolClassNameSL { get; set; }

        public void PopulateStudentOptSubjects(SchoolContext context,
                                               Student student)
        {
            var allOptSubjects = context.OptSubjects;
            var studentOptSubjects = new HashSet<int>(
                student.StudentOptSubjectEnrollments.Select(c => c.OptSubjectId));
            AssignedOptSubjectDataList = new List<AssignedOptSubjectData>();
            foreach (var optSubject in allOptSubjects)
            {
                AssignedOptSubjectDataList.Add(new AssignedOptSubjectData
                {
                    OptSubjectId = optSubject.Id,
                    Title = optSubject.Name,
                    Assigned = studentOptSubjects.Contains(optSubject.Id)
                });
            }
        }

        public void UpdateInstructorCourses(SchoolContext context,
            string[] selectedOptSubjects, Student studentToUpdate)
        {

            if (selectedOptSubjects == null)
            {
                studentToUpdate.StudentOptSubjectEnrollments = new List<StudentOptSubjectEnrollment>();
                return;
            }

            var selectedOptSubjectsHS = new HashSet<string>(selectedOptSubjects);
            var studentOptSubjects = new HashSet<int>
                (studentToUpdate.StudentOptSubjectEnrollments.Select(c => c.OptSubject.Id));
            foreach (var optSubject in context.OptSubjects)
            {
                if (selectedOptSubjectsHS.Contains(optSubject.Id.ToString()))
                {
                    if (!studentOptSubjects.Contains(optSubject.Id))
                    {
                        studentToUpdate.StudentOptSubjectEnrollments.Add(
                            new StudentOptSubjectEnrollment
                            {
                                StudentId = studentToUpdate.Id,
                                OptSubjectId = optSubject.Id
                            });
                    }
                }
                else
                {
                    if (studentOptSubjects.Contains(optSubject.Id))
                    {
                        StudentOptSubjectEnrollment OptSubjectToRemove
                            = studentToUpdate
                                .StudentOptSubjectEnrollments
                                .SingleOrDefault(i => i.OptSubjectId == optSubject.Id);
                        context.Remove(OptSubjectToRemove);
                    }
                }
            }
        }


        public void PopulateClassesDropDownList(SchoolContext _context,
            object selectedSchoolClass = null)
        {
            var classesQuery = from d in _context.SchoolClasses
                orderby d.Name // Sort by name.
                select d;

            SchoolClassNameSL = new SelectList(classesQuery.AsNoTracking(),
                "Id", "Name", selectedSchoolClass);
        }
        public void UpdateStudentSchoolClass(SchoolContext context,
           int selectedSchoolClass, Student studentToUpdate)
        {

            var studentSchoolClass = studentToUpdate.StudentSchoolClassEnrollment.SchoolClassId;

            context.Remove(studentToUpdate.StudentSchoolClassEnrollment);

            studentToUpdate.StudentSchoolClassEnrollment =
                new StudentSchoolClassEnrollment()
                {
                    StudentId = studentToUpdate.Id,
                    SchoolClassId = selectedSchoolClass
                };
        }

    }
    }
