using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_App.Models
{
    public class StudentMarks
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarksId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }



        [ForeignKey("Subjects")]
        public int SubjectsId { get; set; }
        public virtual Subjects Subjects { get; set; }

        [Required]
        public float Marks { get; set; }

    }
}
