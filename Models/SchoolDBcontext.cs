using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace School_App.Models
{
    public class SchoolDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentMarks> StudentMarks { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<User> User { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        //public protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Data Source=D:/Projects/School App/School_App/database.db";
        //    optionsBuilder.UseSqlite(connectionString);
        //    optionsBuilder.LogTo(message => Console.WriteLine(message));
        //}



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Student>()
        //        .HasKey(s => s.StudentsId);

        //    modelBuilder.Entity<Subjects>()
        //        .HasKey(s => s.SubjectsId);

        //    modelBuilder.Entity<StudentMarks>()
        //        .HasKey(sm => sm.MarksId);

        //    modelBuilder.Entity<StudentMarks>()
        //        .HasRequired(sm => sm.Student)
        //        .WithMany()
        //        .HasForeignKey(sm => sm.StudentId);

        //    modelBuilder.Entity<StudentMarks>()
        //        .HasRequired(sm => sm.Subjects)
        //        .WithMany()
        //        .HasForeignKey(sm => sm.SubjectsId);
        //}
    }
}
