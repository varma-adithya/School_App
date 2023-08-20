using Microsoft.EntityFrameworkCore;

namespace School.Data.Models
{
	public class SchoolDbContext : DbContext
	{
		private readonly string _connectionString;

		public SchoolDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public DbSet<StudentDetail> Students { get; set; }
		public DbSet<Assessment> Assessments { get; set; }
		public DbSet<StudentAssessment> StudentAssessments { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<ClassSubject> ClassSubjects { get; set; }
		public DbSet<ClassStudent> ClassStudents { get; set; }
		public DbSet<AcademicYear> AcademicYears { get; set; }
		public DbSet<Class> Classes { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite(_connectionString);
			}
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AcademicYear>().HasIndex(x => x.StartYear).IsUnique();
        }
    }
}
