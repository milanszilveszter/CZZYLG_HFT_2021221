using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Classrooms")]
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)] 
        public string ClassroomNumber { get; set; }

        [NotMapped]
        [JsonIgnore]  // NAVIGATION PROP
        public virtual ICollection<Student> Students { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [NotMapped]
        [JsonIgnore] // NAVIGATION PROP
        public virtual Teacher Teacher { get; set; }

        public Classroom()
        {
            Students = new HashSet<Student>();
        }
    }
}
