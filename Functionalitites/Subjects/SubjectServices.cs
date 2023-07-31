using School_App.Models;

namespace School_App.Functionalitites
{
    internal class SubjectServices
    {

        private readonly SchoolDbContext context;

        public SubjectServices(SchoolDbContext context)
        {
            this.context = context;
        }

        public void CreateSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }


        public Subject ReadSubject(int subjectId)
        {
            return context.Subjects.Find(subjectId);
        }


        public void UpdateSubject(Subject updatedSubject)
        {
            var existingSubject = context.Subjects.Find(updatedSubject.SubjectId);
            if (existingSubject != null)
            {
                existingSubject.SubjectName = updatedSubject.SubjectName;
                existingSubject.Description = updatedSubject.Description;
                context.SaveChanges();
            }
        }

        public void DeleteSubject(int subjectId)
        {
            var subject = context.Subjects.Find(subjectId);
            if (subject != null)
            {
                context.Subjects.Remove(subject);
                context.SaveChanges();
            }
        }

        public List<Subject> AllSubjects()
        {
            return context.Subjects.ToList();
        }

    }
}
