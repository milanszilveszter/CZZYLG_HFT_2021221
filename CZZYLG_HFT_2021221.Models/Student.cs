﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Grade { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }

        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

    }
}
