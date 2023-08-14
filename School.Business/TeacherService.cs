using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public class TeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public void AddTeacher(Teacher teacher)
            => _repository.Add(teacher);

        public void UpdatTeacher(Teacher teacher)
            => _repository.Update(teacher);

        public Teacher GetTeacher(int id)
            => _repository.GetById(id);
    }
}