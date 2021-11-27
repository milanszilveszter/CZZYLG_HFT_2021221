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
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(c => c.Teacher)
                    .WithOne(t => t.Course)
                    .HasForeignKey<Teacher>(c => c.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Teacher t1 = new Teacher() { Id = 1, Name = "Kovács András" , Age = 28};
            Teacher t2 = new Teacher() { Id = 2, Name = "Szőke Magdolna", Age = 43 };
            Teacher t3 = new Teacher() { Id = 3, Name = "Vajda István", Age = 46 };

            Course c1 = new Course() { Id = 1, CourseName = "Haladó Fejlesztési Technikák", TeacherId = t1.Id };
            Course c2 = new Course() { Id = 2, CourseName = "Diszkrét Matematika és Lineáris Algebra I.", TeacherId = t2.Id };                  
            Course c3 = new Course() { Id = 3, CourseName = "Analízis I.", TeacherId = t3.Id};

            Student s1 = new Student() { Id = 1, Name = "Kiss Ádám", Grade = 3.19 };
            Student s2 = new Student() { Id = 2, Name = "Balogh Róbert", Grade = 3.4 };
            Student s3 = new Student() { Id = 3, Name = "Kovács Julianna", Grade = 4.44 };
            Student s4 = new Student() { Id = 4, Name = "Gercse Ábel", Grade = 2.34 };
            Student s5 = new Student() { Id = 5, Name = "Magyar Andor", Grade = 3 };
            Student s6 = new Student() { Id = 6, Name = "Kertész Csaba", Grade = 2.1 };

            modelBuilder.Entity<Teacher>().HasData(t1, t2, t3);
            modelBuilder.Entity<Course>().HasData(c1, c2, c3);
            modelBuilder.Entity<Student>().HasData(s1, s2, s3, s4, s5, s6);
        }
    }
}
