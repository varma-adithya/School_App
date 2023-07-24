using School_App.Functionalitites.Student;
using School_App.Functionalitites.Subjects;
using School_App.Functionalitites.User;
using System;

class Program
{
    static void Main(string[] args)
    { 
        using (var context = new SchoolDbContext())
        {
            while (true)
            {
                Console.WriteLine("Hello:");
                Console.WriteLine("Enter menu to go to");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Marks");
                Console.WriteLine("3. Subject");
                Console.WriteLine("4. Update User");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var Stud = new Studentfunc();
                        Stud.ShowMenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        var Sub = new Subjectsfunc();
                        Sub.ShowMenu();
                        break;
                    case 4:
                        var User = new Userfunc();
                        User.ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }


}
