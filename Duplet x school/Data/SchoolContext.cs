using Duplet_x_school.Models;
using Microsoft.EntityFrameworkCore;


namespace Duplet_x_school.Data

{

    public class SchoolContext : DbContext

    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)

        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Kabinet> Kabinets { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<OptSubject> OptSubjects { get; set; }
        public DbSet<StudentOptSubjectEnrollment> OptSubjectEnrollments { get; set; }
        public DbSet<OptSubjectTeacherAssignment> OptSubjectTeacherAssignments { get; set; }
        public DbSet<SchoolClassSubjectAssignment> SubjectAssignments { get; set; }
        public DbSet<TeacherSubjectAssignment> SubjectTeacherAssignments { get; set; }
        public DbSet<StudentSchoolClassEnrollment> StudentSchoolClassEnrollments { get; set; }
        public DbSet<TeacherSchoolClassAssignment> TeacherSchoolClassAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kabinet>().ToTable("Kabinet");

            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<SchoolClass>().ToTable("SchoolClass");

            modelBuilder.Entity<Student>().ToTable("Student");
            
            modelBuilder.Entity<Subject>().ToTable("Subject");

            modelBuilder.Entity<OptSubject>().ToTable("OptSubject");

            modelBuilder.Entity<StudentOptSubjectEnrollment>().ToTable("OptSubjectEnrollment");

            modelBuilder.Entity<OptSubjectTeacherAssignment>().ToTable("OptSubjectTeacherAssignment");

            modelBuilder.Entity<SchoolClassSubjectAssignment>().ToTable("SchoolClassSubjectAssignment");

            modelBuilder.Entity<TeacherSubjectAssignment>().ToTable("SubjectTeacherAssignment");

            modelBuilder.Entity<StudentSchoolClassEnrollment>().ToTable("StudentSchoolClassEnrollment");

            modelBuilder.Entity<OptSubjectTeacherAssignment>()
                .HasKey(c => new { c.OptSubjectId, c.TeacherId });

            modelBuilder.Entity<TeacherSubjectAssignment>()
                .HasKey(c => new { c.SubjectId, c.TeacherId });

            modelBuilder.Entity<SchoolClassSubjectAssignment>()
                .HasKey(c => new { c.SubjectId, c.SchoolClassId });

            modelBuilder.Entity<TeacherSubjectAssignment>()
                .HasKey(c => new {c.SubjectId, c.TeacherId});

            modelBuilder.Entity<TeacherSchoolClassAssignment>()
                .HasKey(c => new { c.TeacherId, c.SchoolClassId });
        }

    }

}
