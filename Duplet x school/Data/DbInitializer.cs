using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Duplet_x_school.Models;

namespace Duplet_x_school.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var kabinets = new Kabinet[]
            {
                new Kabinet {Name = "101"},
                new Kabinet {Name = "102"},
                new Kabinet {Name = "103"},
                new Kabinet {Name = "104"},
                new Kabinet {Name = "105"},
                new Kabinet {Name = "106"},
            };

            context.Kabinets.AddRange(kabinets);
            context.SaveChanges();

            var teachers = new Teacher[]
            {
                new Teacher { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11"), KabinetId = 1},
                new Teacher { FirstMidName = "Pavel",     LastName = "Maksimov",
                    HireDate = DateTime.Parse("1995-03-11"), KabinetId = 2}
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            var classes = new SchoolClass[]
            {
                new SchoolClass { Name = "1A", TeacherId = 1, KabinetId = 1},
                new SchoolClass { Name = "2A", TeacherId = 2, KabinetId = 1},
                new SchoolClass { Name = "3A", TeacherId = 1, KabinetId = 1}
            };

            context.SchoolClasses.AddRange(classes);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander"},
                new Student { FirstMidName = "Ilya",   LastName = "Filimonau"},
                new Student { FirstMidName = "Veronica",   LastName = "Vanadzins"},
                new Student { FirstMidName = "Nikita",   LastName = "Shamlov"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject { Name = "Mathematics", Description = "This is mathematics" },
                new Subject { Name = "Chemistry", Description = "This is chemisrty" },
                new Subject { Name = "Art", Description = "This is art" },
                new Subject { Name = "Music", Description = "This is music" },
                new Subject { Name = "English", Description = "This is english" },
                new Subject { Name = "Literature", Description = "This is literature" },
                new Subject { Name = "Physics", Description = "This is physics" },
                new Subject { Name = "Biology", Description = "This is biology" }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var optsubjects = new OptSubject[]
            {
                new OptSubject { Name = "Programming", Description = "This is programming"},
                new OptSubject { Name = "Robotics", Description = "This is robotics"}
            };

            context.OptSubjects.AddRange(optsubjects);
            context.SaveChanges();

            var optsubjectenrollments = new StudentOptSubjectEnrollment[]
            {
                new StudentOptSubjectEnrollment { OptSubjectId = 1, StudentId = 1 },
                new StudentOptSubjectEnrollment { OptSubjectId = 2, StudentId = 2 }
            };

            context.OptSubjectEnrollments.AddRange(optsubjectenrollments);
            context.SaveChanges();
            
    
            var optsubjectteacherassignments = new OptSubjectTeacherAssignment[]
            {
                new OptSubjectTeacherAssignment { OptSubjectId = 1, TeacherId = 1 },
                new OptSubjectTeacherAssignment { OptSubjectId = 2, TeacherId = 2 }
            };

            context.OptSubjectTeacherAssignments.AddRange(optsubjectteacherassignments);
            context.SaveChanges();


            var subjectassignments = new SchoolClassSubjectAssignment[]
            {
                new SchoolClassSubjectAssignment { SubjectId = 1, SchoolClassId = 1 },
                new SchoolClassSubjectAssignment { SubjectId = 2, SchoolClassId = 2 }
            };

            context.SubjectAssignments.AddRange(subjectassignments);
            context.SaveChanges();

            var subjectteacherassignments = new TeacherSubjectAssignment[]
            {
                new TeacherSubjectAssignment { SubjectId = 1, TeacherId = 1 },
                new TeacherSubjectAssignment { SubjectId = 2, TeacherId = 2 }
            };

            context.SubjectTeacherAssignments.AddRange(subjectteacherassignments);
            context.SaveChanges();

            var studentschoolclassenrollments = new StudentSchoolClassEnrollment[]
            {
                new StudentSchoolClassEnrollment { StudentId = 1, SchoolClassId = 1 },
                new StudentSchoolClassEnrollment { StudentId = 3, SchoolClassId = 2 },
                new StudentSchoolClassEnrollment { StudentId = 4, SchoolClassId = 3 },
                new StudentSchoolClassEnrollment { StudentId = 2, SchoolClassId = 1 }
            };

            context.StudentSchoolClassEnrollments.AddRange(studentschoolclassenrollments);
            context.SaveChanges();

            var teacherschoolclassassignments = new TeacherSchoolClassAssignment[]
            {
                new TeacherSchoolClassAssignment {TeacherId = 1, SchoolClassId = 1},
                new TeacherSchoolClassAssignment {TeacherId = 2, SchoolClassId = 2}
            };

            context.TeacherSchoolClassAssignments.AddRange(teacherschoolclassassignments);
            context.SaveChanges();
        }
    }
}