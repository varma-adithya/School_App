using School.Business;
using School.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ConsoleApp.UI
{
    public class SubjectPage : ISubjectPage
    {
        private ISubjectService _subjectService;
        public SubjectPage(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public void SubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Subject Menu:");
                Console.WriteLine("1. Add Subjects");
                Console.WriteLine("2. Show Subjects");
                Console.WriteLine("3. Update Subject Details");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        AddSubject();
                        break;
                    case 2:
                        ShowAllSubjects();
                        break;
                    case 3:
                        UpdateSubject();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        public void AddSubject()
        {
            Console.Clear();
            Console.WriteLine("Enter Subject Name:");
            var _name = Console.ReadLine();

            Console.WriteLine("Enter Subject Desciption:");
            var _desc = Console.ReadLine();

            var subject = new Subject() { Name=_name , Description = _desc};
            _subjectService.AddSubject(subject);
            Console.WriteLine("Subject Added Successfully!");
            Console.WriteLine("Enter any key to go to menu!");
            Console.ReadKey();

        }

        public void ShowAllSubjects()
        {
            foreach (var subject in _subjectService.GetAllSubjects())
            {
                Console.WriteLine($"Subject Id: {subject.Id}");
                Console.WriteLine($"Subject Name: {subject.Name}");
                Console.WriteLine($"Subject Description: {subject.Description}");
            }
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }

        public void ShowSubjectDetails(int subjectid)
        {
            var existingsubject = _subjectService.GetSubject(subjectid);
            if (existingsubject != null)
            {
                Console.WriteLine($"Subject Id: {existingsubject.Id}");
                Console.WriteLine($"Subject Name: {existingsubject.Name}");
                Console.WriteLine($"Subject Description: {existingsubject.Description}");
                Console.WriteLine("Enter any key to go back");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Subject not found!");
                Console.WriteLine("Enter any key to go back");
                Console.ReadKey();
                return;
            }
        }


        public void UpdateSubject()
        {
            Console.WriteLine("Enter the subject id to be updated:");
            if (int.TryParse(Console.ReadLine(), out int subjectid))
            {
                var existingsubject = _subjectService.GetSubject(subjectid);
                if (existingsubject != null)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Subject Name:");
                    var _name = Console.ReadLine();

                    Console.WriteLine("Enter Subject Desciption:");
                    var _desc = Console.ReadLine();

                    var subject = new Subject() { Name = _name, Description = _desc };
                    _subjectService.UpdateSubject(subject);
                    Console.WriteLine("Subject Updated Successfully!");
                    Console.WriteLine("Enter any key to go back");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Subject not found!");
                    Console.WriteLine("Enter any key to go back");
                    Console.ReadKey();
                    return;
                }
            }
            else UpdateSubject();
        }
    }
}
