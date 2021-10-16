using System;
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

        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }

        [NotMapped]
        public virtual Course Course { get; set; }
        
        public Teacher()
        {
            Students = new HashSet<Student>();
        }
    }
}
