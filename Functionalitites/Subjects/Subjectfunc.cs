using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_App.Models;

namespace School_App.Functionalitites.Subjects
{
    public class Subjectsfunc
    {

        private readonly SchoolDbContext context;

        public Subjectsfunc(SchoolDbContext context)
        {
            this.context = context;
        }

        public void CreateSubjects()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter Subjects Name: ");
                string inName = Console.ReadLine();

                Console.Write("Enter Subjects Desciption: ");
                string inDesc = Console.ReadLine();


                var Subjects = new Models.Subject
                {
                    SubjectName = inName,
                    Description = inDesc
                };

                context.Subjects.Add(Subjects);

                ReadSubjects(Subjects.SubjectsId);
                Console.WriteLine("Please note Subjects ID!! It is required to search a Subjects");

                context.SaveChanges();

                Console.WriteLine("Subjects added successfully!");
            }
        }

        public void ViewSubjects()
        {
            Console.Write("Enter Subjects ID to view: ");
            int SubjectsId;
            if (int.TryParse(Console.ReadLine(), out SubjectsId))
            {
                ReadSubjects(SubjectsId);
            }
            else
            {
                Console.WriteLine("Invalid Subjects ID format.");
            }
        }

        public void ReadSubjects(int SubjectsId)
        {
            //using (var context = new SchoolDbContext())
            {
                var Subjects = context.Subjects.Find(SubjectsId);
                if (Subjects != null)
                {
                    Console.WriteLine($"Subjects ID: {Subjects.SubjectsId}");
                    Console.WriteLine($"Subject Name: {Subjects.SubjectName}");
                    Console.WriteLine($"Subject Description: {Subjects.Description}");
                }
                else
                {
                    Console.WriteLine("Subject not found.");
                }
            }
        }

        public void UpdateSubjects()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter Subjects ID to update: ");
                int SubjectsId = int.Parse(Console.ReadLine());

                var Subjects = context.Subjects.Find(SubjectsId);
                if (Subjects != null)
                {
                    Console.Write("Enter updated Subject Name: ");
                    Subjects.SubjectName = Console.ReadLine();

                    Console.Write("Enter updated Subject Description: ");
                    Subjects.Description = Console.ReadLine();


                    context.SaveChanges();

                    Console.WriteLine("Subject updated successfully!");
                }
                else
                {
                    Console.WriteLine("Subject not found.");
                }
            }
        }

        public void DeleteSubjects()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter Subjects's ID to delete: ");
                int SubjectsId = int.Parse(Console.ReadLine());

                var Subjects = context.Subjects.Find(SubjectsId);
                if (Subjects != null)
                {
                    context.Subjects.Remove(Subjects);
                    context.SaveChanges();

                    Console.WriteLine("Subjects deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Subjects not found.");
                }
            }
        }

        public void ShowMenu()
        {
            // Show a menu to the user
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Subject");
                Console.WriteLine("2. Update Subject");
                Console.WriteLine("3. Delete Subject");
                Console.WriteLine("4. Show info about Subject");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateSubjects();
                        break;
                    case 2:
                        UpdateSubjects();
                        break;
                    case 3:
                        DeleteSubjects();
                        break;
                    case 4:
                        ViewSubjects();
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
