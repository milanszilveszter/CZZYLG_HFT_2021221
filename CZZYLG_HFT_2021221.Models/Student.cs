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

        [NotMapped] // NAVIGATION PROPERTY
        public virtual Class Class { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }

    }
}
