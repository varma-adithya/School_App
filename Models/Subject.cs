namespace School_App.Models
{
	public class Subject : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
