using CZZYLG_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Data
{
    public class SchoolContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public SchoolContext()
        {
            Database.EnsureCreated();
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>(entity => {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(c => c.Teacher)
                    .WithOne(t => t.Course)
                    .HasForeignKey<Teacher>(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Teacher t1 = new Teacher() { TeacherId = 1, Name = "Kovács András" , Age = 28};
            Teacher t2 = new Teacher() { TeacherId = 2, Name = "Szőke Magdolna", Age = 43 };
            Teacher t3 = new Teacher() { TeacherId = 3, Name = "Vajda István", Age = 46 };

            Course c1 = new Course() { CourseId = 1, CourseName = "Haladó Fejlesztési Technikák", TeacherId = t1.TeacherId };
            Course c2 = new Course() { CourseId = 2, CourseName = "Diszkrét Matematika és Lineáris Algebra I.", TeacherId = t2.TeacherId };
            Course c3 = new Course() { CourseId = 3, CourseName = "Analízis I.", TeacherId = t3.TeacherId};

            Student s1 = new Student() { StudentId = 1, Name = "Kiss Ádám", Grade = 3.19, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 1, CourseId = c1.CourseId }, 
                new StudentCourses() { StudentId = 1, CourseId = c2.CourseId } } 
            };
            Student s2 = new Student() { StudentId = 2, Name = "Balogh Róbert", Grade = 3.4, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 2, CourseId = c1.CourseId }, 
                new StudentCourses() { StudentId = 2, CourseId = c3.CourseId } }
            };
            Student s3 = new Student() { StudentId = 3, Name = "Kovács Julianna", Grade = 4.44, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 3, CourseId = c2.CourseId } }
            };
            Student s4 = new Student() { StudentId = 4, Name = "Gercse Ábel", Grade = 2.34, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 4, CourseId = c1.CourseId }, 
                new StudentCourses() { StudentId = 4, CourseId = c3.CourseId } }
            };
            Student s5 = new Student() { StudentId = 5, Name = "Magyar Andor", Grade = 3, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 5, CourseId = c1.CourseId }, 
                new StudentCourses() { StudentId = 5, CourseId = c2.CourseId }, 
                new StudentCourses() { StudentId = 5, CourseId = c3.CourseId } }
            };
            Student s6 = new Student() { StudentId = 6, Name = "Kertész Csaba", Grade = 2.1, StudentCourses = new List<StudentCourses>()
            {
                new StudentCourses() { StudentId = 6, CourseId = c1.CourseId }, 
                new StudentCourses() { StudentId = 6, CourseId = c2.CourseId }, 
                new StudentCourses() { StudentId = 6, CourseId = c2.CourseId } }
            };

            modelBuilder.Entity<Teacher>().HasData(t1, t2, t3);
            modelBuilder.Entity<Course>().HasData(c1, c2, c3);
            modelBuilder.Entity<Student>().HasData(s1, s2, s3, s4, s5, s6);
        }
    }
}
