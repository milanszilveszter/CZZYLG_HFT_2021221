﻿using CZZYLG_HFT_2021221.Models;
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
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Student> Students { get; set; }
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

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(s => s.Classroom)
                    .WithMany(c => c.Students)
                    .HasForeignKey(s => s.ClassroomId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasOne(t => t.Classroom)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey<Classroom>(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Teacher t1 = new Teacher() { Id = 1, Name = "Kiss Tamás" , Age = 28, Subject = "Matematika"};
            Teacher t2 = new Teacher() { Id = 2, Name = "Magyar Julianna", Age = 43, Subject = "Magyar nyelv és Irodalom" };
            Teacher t3 = new Teacher() { Id = 3, Name = "Vajda Márk", Age = 46, Subject = "Testnevelés" };

            Classroom c1 = new Classroom() { Id = 1, ClassroomNumber = "3A", TeacherId = 1 };
            Classroom c2 = new Classroom() { Id = 2, ClassroomNumber = "12A", TeacherId = 2 };                  
            Classroom c3 = new Classroom() { Id = 3, ClassroomNumber = "21B", TeacherId = 3 };

            Student s1 = new Student() { Id = 1, Name = "Kiss Ádám", Grade = 3.19, ClassroomId = 1 };
            Student s2 = new Student() { Id = 2, Name = "Balogh Róbert", Grade = 3.4, ClassroomId = 1 };
            Student s3 = new Student() { Id = 3, Name = "Kovács Julianna", Grade = 4.44, ClassroomId = 2 };
            Student s4 = new Student() { Id = 4, Name = "Gercse Ábel", Grade = 2.34, ClassroomId = 2 };
            Student s5 = new Student() { Id = 5, Name = "Magyar Andor", Grade = 3, ClassroomId = 3 };
            Student s6 = new Student() { Id = 6, Name = "Kertész Csaba", Grade = 2.1, ClassroomId = 3 };

            modelBuilder.Entity<Teacher>().HasData(t1, t2, t3);
            modelBuilder.Entity<Classroom>().HasData(c1, c2, c3);
            modelBuilder.Entity<Student>().HasData(s1, s2, s3, s4, s5, s6);
        }
    }
}
