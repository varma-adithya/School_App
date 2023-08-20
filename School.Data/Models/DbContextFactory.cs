using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace School.Data.Models
{
	public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
	{
		public SchoolDbContext CreateDbContext(string[] args)
		{
			return new SchoolDbContext("Data Source=school_database.db");
		}
	}
}
