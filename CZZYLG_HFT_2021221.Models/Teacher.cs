using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CZZYLG_HFT_2021221.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, 150)]
        public int Age { get; set; }

        public string Subject { get; set; }

        [ForeignKey(nameof(Classroom))]
        public int ClassroomId { get; set; }

        [NotMapped]
        [JsonIgnore] // NAVIGATION PROP
        public virtual Classroom Classroom { get; set; }
    }
}
