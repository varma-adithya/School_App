using School.Business;
using School.Data.Models;

namespace School.ConsoleApp.UI
{
    public class StudentPage : IStudentPage
    {
        private IStudentService _studentservice;

        public StudentPage(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        public void SubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Update Student Details");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ShowAllStudents();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public void AddStudent()
        {
            Console.Clear();

            Console.WriteLine("Enter Student name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student date of birth:");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                Console.WriteLine("Enter Student Gender (Male/Female)(Case-Sensitive!):");
                if (Enum.TryParse<Gender>(Console.ReadLine(), out Gender sgender))
                {
                    Console.WriteLine("Enter Student Address:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter Student Contact Number:");
                    if (long.TryParse(Console.ReadLine(), out long contactNumber))
                    {
                        var student = new StudentDetail
                        {
                            Name = name,
                            DateOfBirth = dateOfBirth,
                            Gender = sgender,
                            Address = address,
                            ContactNumber = contactNumber
                        };

                        _studentservice.AddStudent(student);

                        Console.WriteLine("Student added successfully");
                        Console.WriteLine("Enter any key to go back");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {AddStudent();}
                }
                else
                { AddStudent();}
            }
            else
            { AddStudent(); }

            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
        }


        public void ShowStudentDetails(int studentid)
        {
            var student = _studentservice.GetStudentdetails(studentid);
            Console.WriteLine($"Student Id: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Date of Birth: {student.DateOfBirth}");
            Console.WriteLine($"Student Contact Number: {student.ContactNumber}");
            Console.WriteLine($"Student Gender: {student.Gender}");
            Console.WriteLine($"Student Address: {student.Address}");
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }

        public void ShowAllStudents()
        {
            foreach (var student in _studentservice.GetAllStudents())
            {
                Console.WriteLine($"Student Id: {student.Id}");
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Student Date of Birth: {student.DateOfBirth}");
                Console.WriteLine($"Student Contact Number: {student.ContactNumber}");
                Console.WriteLine($"Student Gender: {student.Gender}");
                Console.WriteLine($"Student Address: {student.Address}");
            }
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }


        public void UpdateStudent()
        {
            Console.WriteLine("Enter the ID of the student you want to update:");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var existingStudent = _studentservice.GetStudentdetails(studentId);

                if (existingStudent != null)
                {
                    Console.WriteLine("Enter Student name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Student date of birth:");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                    {
                        Console.WriteLine("Enter Student Gender (Male/Female)(Case-Sensitive!):");
                        if (Enum.TryParse<Gender>(Console.ReadLine(), out Gender sgender))
                        {
                            Console.WriteLine("Enter Student Address:");
                            string address = Console.ReadLine();

                            Console.WriteLine("Enter Student Contact Number:");
                            if (long.TryParse(Console.ReadLine(), out long contactNumber))
                            {
                                var student = new StudentDetail
                                {
                                    Name = name,
                                    DateOfBirth = dateOfBirth,
                                    Gender = sgender,
                                    Address = address,
                                    ContactNumber = contactNumber
                                };

                                _studentservice.UpdateStudent(student);

                                Console.WriteLine("Student updated successfully");
                                Console.WriteLine("Enter any key to go back");
                                Console.ReadKey();
                                return;
                            }
                            else
                            { UpdateStudent(); }
                        }
                        else
                        { UpdateStudent(); }
                    }
                    else
                    { UpdateStudent(); }
                }
                else
                {
                    Console.WriteLine("Student not found! Enter any key to return to menu.");
                    Console.ReadKey();
                    return;
                }

            }
            else
            {
                UpdateStudent();
            }
        }
    }
}
