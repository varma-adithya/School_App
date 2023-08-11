using School.Data.Models;

namespace School.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class, IId
	{
		private readonly SchoolDbContext context;

		public Repository(SchoolDbContext Context)
		{
			context = Context;
		}

		public void Add(T entity)
		{
			context.Set<T>().Add(entity);
			context.SaveChanges();
		}

		public IEnumerable<T> GetAll()
		{
			return context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return context.Set<T>().Find(id);
		}

		public void Update(T entity)
		{
			var existing = GetById(entity.Id);
			if (existing == null)
			{
				throw new Exception($"{nameof(T)} entry not found");
			}
			else
			{
				context.Set<T>().Update(entity);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var existing = context.Set<T>().Find(id)
;
			if (existing == null)
			{
				throw new Exception($"{nameof(T)} entry not found");
			}

			context.Set<T>().Remove(existing);
			context.SaveChanges();
		}


	}
}