namespace School.Data.Models
{
	public class AcademicYear : IId
	{
		public int Id { get; set; }

		// Shouldnt be greater current year
		public int StartYear { get; set; }

		// Should ne StartYear + 1
		public int EndYear { get; set; }

		public string DisplayName => $"{StartYear} - {EndYear}";
	}
}
