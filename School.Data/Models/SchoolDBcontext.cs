using Microsoft.EntityFrameworkCore;

namespace School.Data.Models
{
	public class SchoolDbContext : DbContext
	{
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AcademicYear>().HasIndex(x => x.StartYear).IsUnique();
        }
    }
}
