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
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<OptSubject> OptSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<Kabinet>().ToTable("Kabinet");

            modelBuilder.Entity<Class>().ToTable("Class");

            modelBuilder.Entity<Student>().ToTable("Student");
            
            modelBuilder.Entity<Subject>().ToTable("Subject");

            modelBuilder.Entity<OptSubject>().ToTable("OptSubject");

        }

    }

}
