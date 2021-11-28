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
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public double Grade { get; set; }


        [ForeignKey(nameof(ClassRoom))]
        public int ClassRoomId { get; set; }
        [NotMapped]
        public virtual ClassRoom ClassRoom { get; set; }

        [NotMapped]
        [JsonIgnore] // NAVIGATION PROP
        public ICollection<Teacher> Teachers { get; set; }

        public Student()
        {
            Teachers = new HashSet<Teacher>();
        }
    }
}
