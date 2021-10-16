using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    public class StudentCourses
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [NotMapped]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [NotMapped]
        public virtual Course Course { get; set; }

    }
}
