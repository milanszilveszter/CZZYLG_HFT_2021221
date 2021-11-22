﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [NotMapped]
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [NotMapped]
        public virtual Teacher Teacher { get; set; }

        //public Course()
        //{
        //    StudentCourses = new HashSet<StudentCourses>();
        //}
    }
}
