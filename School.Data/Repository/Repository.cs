using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using School.Data.Exceptions;
using School.Data.Models;

namespace School.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class, IId
	{
		private readonly SchoolDbContext _context;

		public Repository(SchoolDbContext context)
		{
			_context = context;
		}

		public void Add(T entity)
		{
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
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
			return _context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
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
                    _context.Set<T>().Update(entity);
                    _context.SaveChanges();
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
			var existing = _context.Set<T>().Find(id)
;
			if (existing == null)
			{
				throw new DataLayerException($"{nameof(T)} entry not found");
			}

			_context.Set<T>().Remove(existing);
			_context.SaveChanges();
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