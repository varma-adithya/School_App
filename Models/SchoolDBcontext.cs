using Microsoft.EntityFrameworkCore;


namespace School_App.Models
{
	public class SchoolDbContext : DbContext
    {
		private readonly string _connectionString = "Data Source=C:/Side/School_App/school_database.db";

		public DbSet<StudentDetail> Students { get; set; }
		public DbSet<Assessment> Assessments { get; set; }
		public DbSet<StudentAssessment> StudentAssessments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
		public DbSet<ClassSubject> ClassSubjects { get; set; }
		public DbSet<Class> Classes { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite(_connectionString);
			}
		}
	}
}
