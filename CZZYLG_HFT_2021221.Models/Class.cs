using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [ForeignKey(nameof(Teacher))] 
        public int TeacherId { get; set; }

        [NotMapped] // NAVIGATION PROPERTY
        public virtual Teacher Teacher { get; set; }

        [NotMapped] // REVERSE NAVIGATION PROPERTY
        public virtual ICollection<Student> Students { get; set; }

        public Class()
        {
            Students = new HashSet<Student>();
        }
    }
}
