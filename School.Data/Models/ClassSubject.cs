namespace School.Data.Models
{
	public class ClassSubject
	{
		public int Id { get; set; }

		public int ClassId { get; set; }

		public int SubjectId { get; set; }

		public int TeacherId { get; set; }

		public Class Class { get; set; }

		public virtual Subject Subject { get; set; }

		public virtual Teacher Teacher { get; set; }


	}
}
