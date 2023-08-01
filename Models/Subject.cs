using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_App.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string? SubjectName { get; set; }
        public string? Description { get; set; }
    }
}
