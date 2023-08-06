namespace School_App.Models
{
    public class StudentAssessment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int AssessmentId { get; set; }

		public float MarksObtained { get; set; }

		public bool HasPassed { get; set; }

		public virtual StudentDetail Student { get; set; }

		public virtual Assessment Assessment { get; set; }

        public bool IsDeleted { get; set; }

    }
}
