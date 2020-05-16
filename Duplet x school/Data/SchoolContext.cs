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
        public DbSet<OptSubjectEnrollment> OptSubjectEnrollments { get; set; }
        public DbSet<OptSubjectTeacherAssignment> OptSubjectTeacherAssignments { get; set; }
        public DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        public DbSet<SubjectTeacherAssignment> SubjectTeacherAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<Kabinet>().ToTable("Kabinet");

            modelBuilder.Entity<SchoolClass>().ToTable("Class");

            modelBuilder.Entity<Student>().ToTable("Student");
            
            modelBuilder.Entity<Subject>().ToTable("Subject");

            modelBuilder.Entity<OptSubject>().ToTable("OptSubject");

            modelBuilder.Entity<OptSubjectEnrollment>().ToTable("OptSubjectEnrollment");

            modelBuilder.Entity<OptSubjectTeacherAssignment>().ToTable("OptSubjectTeacherAssignment");

            modelBuilder.Entity<SubjectAssignment>().ToTable("SubjectAssignment");

            modelBuilder.Entity<SubjectTeacherAssignment>().ToTable("SubjectTeacherAssignment");

            modelBuilder.Entity<OptSubjectTeacherAssignment>()
                .HasKey(c => new { c.OptSubjectId, c.TeacherId });

            modelBuilder.Entity<SubjectTeacherAssignment>()
                .HasKey(c => new { c.SubjectId, c.TeacherId });
        }

    }

}
