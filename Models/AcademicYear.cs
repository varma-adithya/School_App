namespace School_App.Models
{
	public class AcademicYear : BaseEntity
	{
        public int Id { get; set; }

        // Shouldnt be greater current year
        public int StartYear { get; set; }

        // Should ne StartYear + 1
        public int EndYear { get; set; }

        public string DisplayName => $"{StartYear} - {EndYear}";
    }
}
