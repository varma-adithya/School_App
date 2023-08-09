namespace School_App.Models
{
	public class Class : IId
    {
        public int Id { get; set; }
        
        // Constraint - Standard/Division/Academicyear Unique Constraint
        // Between 1-12
        public int Standard { get; set; } 
        
        // Between A-H
        public string Division { get; set; } 

        public int AcademicYearId { get; set; }

        public int TeacherId { get; set; }

        public AcademicYear AcademicYear { get; set; }

        public virtual Teacher Teacher { get; set; }

    }
}
