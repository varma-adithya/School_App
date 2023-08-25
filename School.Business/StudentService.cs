using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public interface IStudentService
    {
        void AddStudent(StudentDetail student);

        IEnumerable<StudentDetail> GetAllStudents();

        void UpdateStudent(StudentDetail student);

        public StudentDetail GetStudentdetails(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IRepository<StudentDetail> _repository;

        public StudentService(IRepository<StudentDetail> repository)
        {
            _repository = repository;
        }

        public void AddStudent(StudentDetail student)
            => _repository.Add(student);

        public void UpdateStudent(StudentDetail student)
            => _repository.Update(student);

        public StudentDetail GetStudentdetails(int id)
            => _repository.GetById(id);

        IEnumerable<StudentDetail> IStudentService.GetAllStudents()
            => _repository.GetAll().ToList();
    }
}
