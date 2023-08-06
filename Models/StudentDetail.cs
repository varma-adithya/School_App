namespace School_App.Models
{
    public class StudentDetail
    {
        public int Id { get; set; }

        public int RegistrationId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public int ContactNumber { get; set; }

        public StudentStatus Status { get; set; }
    }

	public enum Gender
	{
		Male,
		Female
	}

	public enum StudentStatus
	{
		Active,
		Alumni
	}
}
