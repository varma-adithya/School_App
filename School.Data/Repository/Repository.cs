using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using School.Data.Exceptions;
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
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (IsUniqueConstraintViolation(ex))
                {
					throw new DataLayerException(ErrorMessages.UniqueConstraint, ex);
                }
                
                throw;
            }
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
				throw new DataLayerException($"{nameof(T)} entry not found");
			}
			else
			{
                try
                {
                    context.Set<T>().Update(entity);
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    if (IsUniqueConstraintViolation(ex))
                    {
                        throw new DataLayerException(ErrorMessages.UniqueConstraint, ex);
                    }

                    throw;
                }
			}
		}

		public void Delete(int id)
		{
			var existing = context.Set<T>().Find(id)
;
			if (existing == null)
			{
				throw new DataLayerException($"{nameof(T)} entry not found");
			}

			context.Set<T>().Remove(existing);
			context.SaveChanges();
		}

        private bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            foreach (var entry in ex.Entries)
            {
                if (ex.InnerException is SqliteException sqliteException && sqliteException.SqliteErrorCode == 19)
                {
                    return true;
                }
            }
            return false;
        }
    }
}