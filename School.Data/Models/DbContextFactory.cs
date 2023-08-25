using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace School.Data.Models
{
    public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
	{
		public SchoolDbContext CreateDbContext(string[] args)
		{
            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            var connectionString = "Data Source=..\\School.Console\\bin\\Debug\\net6.0\\school_database.db";
            builder.UseSqlite(connectionString);
            return new SchoolDbContext(builder.Options);
		}
	}
}
