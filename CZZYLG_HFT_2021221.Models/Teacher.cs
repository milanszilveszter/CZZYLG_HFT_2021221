﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Courses))] // IDEGEN KULCS
        public int CourseId { get; set; }

        [NotMapped] // REVERSE NAVIGATION PROPERTY
        public virtual ICollection<Course> Courses { get; set; }

        public Teacher()
        {
            Courses = new HashSet<Course>();
        }
    }
}