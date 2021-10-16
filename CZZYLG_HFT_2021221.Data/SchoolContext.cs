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
            modelBuilder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);





            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasOne(student => student.Class)
            //        .WithMany(clss => clss.Students)
            //        .HasForeignKey(student => student.ClassId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //modelBuilder.Entity<Teacher>(entity =>
            //{
            //    entity.HasMany(teacher => teacher.Classes)
            //        .WithMany(clss => clss.Teacher)
            //        .HasForeignKey(teacher => teacher.ClassId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            //Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            //Brand audi = new Brand() { Id = 3, Name = "Audi" };

            //Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            //Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW 510" };
            //Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 10000, Model = "Citroen C1" };
            //Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 15000, Model = "Citroen C3" };
            //Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "Audi A3" };
            //Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A4" };

            //modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
            //modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2);
        }
    }
}
