using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public interface ITeacherService
    {
        public void AddTeacher(Teacher teacher);
        public void UpdateTeacher(Teacher teacher);
        public Teacher GetTeacher(int id);
        public IEnumerable<Teacher> GetAllTeachers();
    }
    public class TeacherService: ITeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public void AddTeacher(Teacher teacher)
            => _repository.Add(teacher);

        public void UpdateTeacher(Teacher teacher)
            => _repository.Update(teacher);

        public Teacher GetTeacher(int id)
            => _repository.GetById(id);

        IEnumerable<Teacher> ITeacherService.GetAllTeachers()
        => _repository.GetAll().ToList();
    }
}