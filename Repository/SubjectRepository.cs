using School_App.Models;

namespace School_App.Repository
{
public class SubjectRepository
    {
        public SubjectRepository()
        {
        }

        public void Create(Subject subject)
        {
            using (var context = new SchoolDbContext())
            {
                context.Subjects.Add(subject);
                context.SaveChanges();
            }
        }

        public Subject Read(int subjectId)
        {
            using var context = new SchoolDbContext();
            var existing = context.Subjects.Find(subjectId);
            if (existing == null)
            {
                throw new Exception("Subject entry not found");
            }

            return existing;
        }

        public void Update(Subject subject)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Subjects.Find(subject.Id);
                if (existing == null)
                {
                    throw new Exception("Subject entry not found");
                }

                existing.Name = subject.Name;
                existing.Description = subject.Description;

                context.SaveChanges();
            }
        }

        public void Delete(int subjectId)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Subjects.Find(subjectId);
                if (existing == null)
                {
                    throw new Exception("Subject entry not found");
                }

                context.Subjects.Remove(existing);

                context.SaveChanges();
            }
        }
    }
}
