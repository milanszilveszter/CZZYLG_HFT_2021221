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

        [NotMapped]
        [JsonIgnore]
        public virtual Student Student { get; set; }

    }
}
