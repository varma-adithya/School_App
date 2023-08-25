using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public interface IClassService
    {
        public void AddClass(Class _class);
        public void UpdateClass(Class _class);
        public Class GetClass(int id);
        public IEnumerable<Class> GetAllClasses();

    }
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;

        public ClassService(IRepository<Class> repository)
        {
            _repository = repository;
        }

        public void AddClass(Class _class)
            => _repository.Add(_class);

        public void UpdateClass(Class _class)
            => _repository.Update(_class);

        public Class GetClass(int id)
            => _repository.GetById(id);

        IEnumerable<Class> IClassService.GetAllClasses()
            => _repository.GetAll().ToList();

    }
}
