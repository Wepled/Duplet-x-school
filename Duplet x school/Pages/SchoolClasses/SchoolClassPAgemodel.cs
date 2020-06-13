using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duplet_x_school.Data;
using Duplet_x_school.Models;
using Duplet_x_school.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Duplet_x_school.Pages.SchoolClasses
{
    public class SchoolClassPAgemodel : PageModel
    {

        public List<AssignedSubjectData> AssignedSubjectDataList;
        public SelectList KabinetNameSL { get; set; }
        public SelectList TeacherNameSL { get; set; }

        public void PopulateClassSubjects(SchoolContext context,
            SchoolClass schoolClass = null)
        {
            var allSubjects = context.Subjects;
            var schoolClassSubjects = new HashSet<int>();
            if (schoolClass != null)
            {
                schoolClassSubjects = new HashSet<int>(
                    schoolClass.SchoolClassSubjectAssignments.Select(c => c.SubjectId));
            }
            AssignedSubjectDataList = new List<AssignedSubjectData>();
            foreach (var subject in allSubjects)
            {
                AssignedSubjectDataList.Add(new AssignedSubjectData
                {
                    SubjectId = subject.Id,
                    Title = subject.Name,
                    Assigned = schoolClassSubjects.Contains(subject.Id)
                });
            }
        }
        public void UpdateClassSubjects(SchoolContext context,
            string[] selectedSubjects, SchoolClass schoolClassToUpdate = null)
        {

            if (selectedSubjects == null)
            {
                schoolClassToUpdate.SchoolClassSubjectAssignments = new List<SchoolClassSubjectAssignment>();
                return;
            }

            var selectedSubjectsHS = new HashSet<string>(selectedSubjects);
            var teacherSubjects = new HashSet<int>();
            if (schoolClassToUpdate.SchoolClassSubjectAssignments != null)
            {
                teacherSubjects = new HashSet<int>
                    (schoolClassToUpdate.SchoolClassSubjectAssignments.Select(c => c.Subject.Id));
            }
            else
            {
                schoolClassToUpdate.SchoolClassSubjectAssignments = new List<SchoolClassSubjectAssignment>();
            }
            foreach (var subject in context.Subjects)
            {
                if (selectedSubjectsHS.Contains(subject.Id.ToString()))
                {
                    if (!teacherSubjects.Contains(subject.Id))
                    {
                        schoolClassToUpdate.SchoolClassSubjectAssignments.Add(
                            new SchoolClassSubjectAssignment
                            {
                                SchoolClassId = schoolClassToUpdate.Id,
                                SubjectId = subject.Id
                            });
                    }
                }
                else
                {
                    if (teacherSubjects.Contains(subject.Id))
                    {
                        SchoolClassSubjectAssignment SubjectToRemove
                            = schoolClassToUpdate
                                .SchoolClassSubjectAssignments
                                .SingleOrDefault(i => i.SubjectId == subject.Id);
                        context.Remove(SubjectToRemove);
                    }
                }
            }
        }


        public void PopulateKabinetsDropDownList(SchoolContext _context,
            object selectedKabinet = null)
        {
            var query = from d in _context.Kabinets
                orderby d.Name // Sort by name.
                select d;

            KabinetNameSL = new SelectList(query.AsNoTracking(),
                "Id", "Name", selectedKabinet);
        }
        public void UpdateKabinets(SchoolContext context,
            int selectedKabinet, SchoolClass schoolClass)
        {

            var schoolClassKabinet = schoolClass.SchoolClassKabinetAssignment.KabinetId;

            context.Remove(schoolClass.SchoolClassKabinetAssignment);

            schoolClass.SchoolClassKabinetAssignment =
                new SchoolClassKabinetAssignment()
                {
                    KabinetId = schoolClass.Id,
                    SchoolClassId = selectedKabinet
                };
        }
    }
}
