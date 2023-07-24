using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_App.Models
{
    public class Subjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectsId { get; set; }
        
        [Required]
        public string SubjectName { get; set; }
        public string? Description { get; set; }
    }
}
