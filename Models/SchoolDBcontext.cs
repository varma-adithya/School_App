using School_App.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

public class SchoolDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentMarks> StudentMarks { get; set; }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<User> User { get; set; }

    public SchoolDbContext() : base("Data Source=SchoolApp.db")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentsId);

        modelBuilder.Entity<Subjects>()
            .HasKey(s => s.SubjectsId);

        modelBuilder.Entity<StudentMarks>()
            .HasKey(sm => sm.MarksId);

        modelBuilder.Entity<StudentMarks>()
            .HasRequired(sm => sm.Student)
            .WithMany()
            .HasForeignKey(sm => sm.StudentId);

        modelBuilder.Entity<StudentMarks>()
            .HasRequired(sm => sm.Subjects)
            .WithMany()
            .HasForeignKey(sm => sm.SubjectsId);
    }
}
