using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_App.Models;

namespace School_App.Functionalitites.Student
{
    public class Studentfunc
    {
        private readonly SchoolDbContext context;

        public Studentfunc(SchoolDbContext context)
        {
            this.context = context;
        }

        public void CreateStudent()
        {
            int id = 0;
            //using (var context = new SchoolDbContext(this.options))
            {
                Console.Write("Enter student's Name: ");
                string inName = Console.ReadLine();

                Console.Write("Enter student's Class: ");
                string inClass = Console.ReadLine();

                var Student = new Models.Student
                {
                    Name = inName,
                    Class = inClass
                };

                context.Students.Add(Student);
                context.SaveChanges();

                Console.WriteLine("Student added successfully!");



                ReadStudent(Student.StudentsId);
                Console.WriteLine("Please note Student ID!! It is required to search a student");
            }
        }

        public void ViewStudent()
        {
            Console.Write("Enter student's ID to view: ");
            int studentId;
            if (int.TryParse(Console.ReadLine(), out studentId))
            {
                ReadStudent(studentId);
            }
            else
            {
                Console.WriteLine("Invalid student ID format.");
            }
        }

        public void ReadStudent(int studentId)
        {
            //using (var context = new SchoolDbContext())
            {
                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    Console.WriteLine($"Student ID: {student.StudentsId}");
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Class: {student.Class}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        public void UpdateStudent()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter student's ID to update: ");
                int studentId = int.Parse(Console.ReadLine());

                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    Console.Write("Enter updated Name: ");
                    student.Name = Console.ReadLine();

                    Console.Write("Enter updated Class: ");
                    student.Class = Console.ReadLine();


                    context.SaveChanges();

                    Console.WriteLine("Student updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        public void DeleteStudent()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter student's ID to delete: ");
                int studentId = int.Parse(Console.ReadLine());

                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();

                    Console.WriteLine("Student deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Show info about student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateStudent();
                        break;
                    case 2:
                        UpdateStudent();
                        break;
                    case 3:
                        DeleteStudent();
                        break;
                    case 4:
                        ViewStudent();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
