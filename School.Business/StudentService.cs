using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public class StudentService
    {
        private readonly IRepository<StudentDetail> _repository;

        public StudentService(IRepository<StudentDetail> repository)
        {
            _repository = repository;
        }

        public void AddStudent(StudentDetail student)
            => _repository.Add(student);

        public void UpdateClass(StudentDetail student)
            => _repository.Update(student);

        public StudentDetail GetStudent(int id)
            => _repository.GetById(id);
    }
}
