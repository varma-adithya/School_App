using School_App.Models;

namespace School_App.Repository
{
    public class TeacherRepository
    {
        public TeacherRepository()
        {
        }

        public void Create(Teacher teacher)
        {
            using (var context = new SchoolDbContext())
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
        }

        public Teacher Read(int teacherId)
        {
            using var context = new SchoolDbContext();
            var existing = context.Teachers.Find(teacherId);
            if (existing == null)
            {
                throw new Exception("Teacher entry not found");
            }

            return existing;
        }

        public void Update(Teacher teacher)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Teachers.Find(teacher.Id);
                if (existing == null)
                {
                    throw new Exception("Teacher entry not found");
                }

                existing.Name = teacher.Name;

                context.SaveChanges();
            }
        }

        public void Delete(int teacherId)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Teachers.Find(teacherId);
                if (existing == null)
                {
                    throw new Exception("Teacher entry not found");
                }

                context.Teachers.Remove(existing);

                context.SaveChanges();
            }
        }
    }
}
