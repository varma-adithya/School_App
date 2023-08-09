using School_App.Models;

namespace School_App.Repository
{
    public interface IRepository<T> where T :  class, IId
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
