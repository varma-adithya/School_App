using School_App.Models;

namespace School_App.Services
{
	public class StudentService
	{
		public StudentService() 
		{ 
		}

		public void Create(Student student)
		{
			using(var context = new SchoolDbContext())
			{
				context.Students.Add(student);
				context.SaveChanges();
			}
		}

		public Student Read(int studentId)
		{
			using var context = new SchoolDbContext();
			var existing = context.Students.Find(studentId);
			if (existing == null)
			{
				throw new Exception("Student entry not found");
			}

			return existing;
		}

		public void Update(Student student)
		{
			using (var context = new SchoolDbContext())
			{
				var existing = context.Students.Find(student.StudentId);
				if (existing == null)
				{
					throw new Exception("Student entry not found");
				}

				existing.Name = student.Name;
				existing.Class = student.Class;

				context.SaveChanges();
			}
		}

		public void Delete(int studentId)
		{
			using (var context = new SchoolDbContext())
			{
				var existing = context.Students.Find(studentId);
				if (existing == null)
				{
					throw new Exception("Student entry not found");
				}

				context.Students.Remove(existing);

				context.SaveChanges();
			}
		}
	}
}
