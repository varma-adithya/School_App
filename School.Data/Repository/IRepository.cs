using School.Data.Models;

namespace School.Data.Repository
{
	public interface IRepository<T> where T : class, IId
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
