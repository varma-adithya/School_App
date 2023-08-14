using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public class ClassService
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
    }
}
