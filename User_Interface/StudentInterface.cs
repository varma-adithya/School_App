using School_App.Models;
using School_App.Services;

namespace School_App.User_Interface
{
    internal class StudentInterface
    {
        private readonly StudentServices studentServices;

        public StudentInterface(SchoolDbContext Context)
        {
            this.studentServices = new StudentServices(Context);
        }


        public void CreateStudent()
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Class: ");
            var className = Console.ReadLine();
            var newStudent = new Student { Name = name, Class = className };
            if (newStudent.Class != null && newStudent.Name != null)
            {
                int createstatus = studentServices.CreateStudent(newStudent);
                if (createstatus == 0)
                {
                    Console.Write("Student has not been created! Please try again!");
                }
                else Console.Write("Student has been created!");
            }
            else { Console.Write("Student details cannot be null! Please try again!"); }
        }

        public void DisplayStudent()
        {
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = studentServices.FindStudent(studentId);
                if (student != null)
                {
                    Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Class: {student.Class} \n");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }


        public void DisplayAllStudents()
        {
            Console.WriteLine("All Students:\n");
            foreach (var student in studentServices.AllStudents())
            {
                Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Class: {student.Class} \n");
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = studentServices.FindStudent(studentId);
                if (student != null)
                {
                    Console.Write("Enter New Name: ");
                    var newName = Console.ReadLine();
                    if (newName != null) { student.Name = newName; }
                    else { Console.WriteLine("Name = null not allowed. Name not updated."); }

                    Console.Write("Enter New Class: ");
                    var newClass = Console.ReadLine();
                    if (newClass != null) { student.Class = newClass; }
                    else { Console.WriteLine("Class = null not allowed. Class not updated."); }


                    var updatestatus = studentServices.UpdateStudent(student);
                    if (updatestatus > 0) { Console.WriteLine("Student updated successfully!"); }
                    else { Console.WriteLine("Student updation failed!"); }

                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }


        public void DeleteStudent()
        {
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = studentServices.FindStudent(studentId);
                if (student != null)
                {
                    var deletestatus = studentServices.DeleteStudent(studentId);
                    if (deletestatus > 0) { Console.WriteLine("Student deleted successfully!"); }
                    else { Console.WriteLine("Student deletion failed!"); }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }


        public void Menu()
        {
        StudentMenu:

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Show details of a Student");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateStudent();
                        goto StudentMenu;
                    case 2:
                        UpdateStudent();
                        goto StudentMenu;
                    case 3:
                        DeleteStudent();
                        goto StudentMenu;
                    case 4:
                        DisplayAllStudents();
                        goto StudentMenu;
                    case 5:
                        DisplayStudent();
                        goto StudentMenu;
                    case 6:
                        DisplayStudent();
                        goto StudentMenu;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        goto StudentMenu; ;
                }
            }
        }

    }

}
