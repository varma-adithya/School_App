namespace School_App.Models
{
    public class StudentGrade
    {
        public int StudentGradeId { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public float Marks { get; set; }

    }
}
