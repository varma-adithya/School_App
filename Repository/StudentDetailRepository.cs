using School_App.Models;

namespace School_App.Repository
{
    public class StudentDetailRepository
    {
        public StudentDetailRepository()
        {
        }

        public void Create(StudentDetail student)
        {
            using (var context = new SchoolDbContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public StudentDetail Read(int studentId)
        {
            using var context = new SchoolDbContext();
            var existing = context.Students.Find(studentId);
            if (existing == null)
            {
                throw new Exception("Student entry not found");
            }

            return existing;
        }

        public void Update(StudentDetail student)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Students.Find(student.Id);
                if (existing == null)
                {
                    throw new Exception("Student entry not found");
                }

                existing.Name = student.Name;

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
