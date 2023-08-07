using School_App.Models;

namespace School_App.Repository
{
	public class Repository<Class_Type> : IRepository<Class_Type> where Class_Type : BaseEntity
	{
		private readonly SchoolDbContext context;

		public Repository(SchoolDbContext Context)
        {
			context = Context;
        }


		public void Add(Class_Type entity)
		{
			context.Set<Class_Type>().Add(entity);
			context.SaveChanges();
		}

		public IEnumerable<Class_Type> GetAll()
		{
			return context.Set<Class_Type>().ToList();
		}

        public Class_Type GetById(int id)
        {
			return context.Set<Class_Type>().Find(id);
		}

		public void Update(Class_Type entity)
		{
			var existing = GetById(entity.Id);
			if (existing == null)
			{
				throw new Exception($"{nameof(Class_Type)} entry not found");
			}
			else {
				context.Set<Class_Type>().Update(entity);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var existing = context.Set<Class_Type>().Find(id)
;
			if (existing == null)
			{
				throw new Exception($"{nameof(Class_Type)} entry not found");
			}

			context.Set<Class_Type>().Remove(existing);
			context.SaveChanges();
		}


    }
}