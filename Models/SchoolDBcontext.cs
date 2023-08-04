using Microsoft.EntityFrameworkCore;


namespace School_App.Models
{
	public class SchoolDbContext : DbContext
    {
		private readonly string _connectionString = "Data Source=C:/Side/School_App/school_database.db";

		public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite(_connectionString);
			}
		}
	}
}
