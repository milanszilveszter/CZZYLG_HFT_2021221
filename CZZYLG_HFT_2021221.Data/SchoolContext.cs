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


            modelBuilder.Entity<Student>(entity => {
                entity.HasOne(s => s.Teacher)
                    .WithMany(t => t.Students)
                    .HasForeignKey(s => s.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasOne(t => t.Course)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey<Course>(c => c.TeacherId);
            });

            Teacher t1 = new Teacher() { TeacherId = 1, Name = "Kovács András" };
            Teacher t2 = new Teacher() { TeacherId = 2, Name = "Szőke Magdolna" };
            Teacher t3 = new Teacher() { TeacherId = 3, Name = "Vajda István" };

            Course c1 = new Course() { CourseId = 1, CourseName = "Haladó Fejlesztési Technikák", TeacherId = t1.TeacherId };
            Course c2 = new Course() { CourseId = 2, CourseName = "Diszkrét Matematika és Lineáris Algebra I.", TeacherId = t2.TeacherId };
            Course c3 = new Course() { CourseId = 3, CourseName = "Analízis I.", TeacherId = t3.TeacherId};

            Student s1 = new Student() { StudentId = 1, TeacherId = t1.TeacherId, Name = "Kiss Ádám", GradeAvg = 3.19f};
            Student s2 = new Student() { StudentId = 2, TeacherId = t1.TeacherId, Name = "Balogh Róbert", GradeAvg = 3.4f };
            Student s3 = new Student() { StudentId = 3, TeacherId = t2.TeacherId, Name = "Kovács Julianna", GradeAvg = 4.44f };
            Student s4 = new Student() { StudentId = 4, TeacherId = t2.TeacherId, Name = "Gercse Ábel", GradeAvg = 2.34f };
            Student s5 = new Student() { StudentId = 5, TeacherId = t3.TeacherId, Name = "Magyar Andor", GradeAvg = 3f };
            Student s6 = new Student() { StudentId = 6, TeacherId = t3.TeacherId, Name = "Kertész Csaba", GradeAvg = 2.1f };

            modelBuilder.Entity<Teacher>().HasData(t1, t2, t3);
            modelBuilder.Entity<Course>().HasData(c1, c2, c3);
            modelBuilder.Entity<Student>().HasData(s1, s2, s3, s4, s5, s6);             
        }
    }
}
