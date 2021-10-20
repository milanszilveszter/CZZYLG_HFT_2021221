using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        public float GradeAvg { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [NotMapped]
        public virtual Teacher Teacher { get; set; }

        [NotMapped]
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }

        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

    }
}
