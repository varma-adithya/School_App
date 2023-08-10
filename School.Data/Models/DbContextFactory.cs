using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace School.Data.Models
{
	public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
	{
		public SchoolDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
			optionsBuilder.UseSqlite("Data Source=school_database.db");

			return new SchoolDbContext();
		}
	}
}
