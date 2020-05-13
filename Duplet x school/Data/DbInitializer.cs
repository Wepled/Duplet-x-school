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

            var classes = new Class[]
            {
                new Class { Name = "1A", TeacherId = 1, KabinetId = 1},
                new Class { Name = "2A", TeacherId = 2, KabinetId = 1},
                new Class { Name = "3A", TeacherId = 1, KabinetId = 1}
            };

            context.Classes.AddRange(classes);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander",
                     ClassID = 1},
                new Student { FirstMidName = "Ilya",   LastName = "Alexander",
                    ClassID = 1},
                new Student { FirstMidName = "Veronica",   LastName = "Alexander",
                    ClassID = 2},
                new Student { FirstMidName = "Nikita",   LastName = "Alexander",
                    ClassID = 3}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject { Name = "Mathematics" },
                new Subject { Name = "Chemistry" },
                new Subject { Name = "Art" },
                new Subject { Name = "Music" },
                new Subject { Name = "English" },
                new Subject { Name = "Literature" },
                new Subject { Name = "Physics" },
                new Subject { Name = "Biology" }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var optsubjects = new OptSubject[]
            {
                new OptSubject { Name = "Programming"},
                new OptSubject { Name = "Robotics"}
            };

            context.OptSubjects.AddRange(optsubjects);
            context.SaveChanges();
        }
    }
}