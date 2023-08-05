namespace School_App.Models
{
    public class StudentAssessment
    {
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        
        public int AssessmentId { get; set; }

        public virtual Assessment Assessment { get; set; }

        public float MarksObtained { get; set; }
        public bool Haspassed { get; set; }

    }
}
