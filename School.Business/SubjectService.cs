using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public interface ISubjectService
    {
        public void AddSubject(Subject subject);
        public void UpdateSubject(Subject subject);
        public Subject GetSubject(int id);
        public IEnumerable<Subject> GetAllSubjects();
    }
    public class SubjectService:ISubjectService
    {
        private readonly IRepository<Subject> _repository;

        public SubjectService(IRepository<Subject> repository)
        {
            _repository = repository;
        }

        public void AddSubject(Subject student)
            => _repository.Add(student);

        public void UpdateSubject(Subject student)
            => _repository.Update(student);

        public Subject GetSubject(int id)
            => _repository.GetById(id);

        IEnumerable<Subject> ISubjectService.GetAllSubjects()
        =>_repository.GetAll().ToList();
    }
}