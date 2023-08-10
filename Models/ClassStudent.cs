namespace School_App.Models
{
	public class ClassStudent
	{
        public int Id { get; set; }

        // Student cannot be added to another class once assigned
        // Class and student are composite keys
        public int ClassId { get; set; }

        public int StudentDetailId { get; set; }

        public int RollNumber { get; set; }

        public Class Class { get; set; }

        public StudentDetail StudentDetail { get; set; }
    }
}
