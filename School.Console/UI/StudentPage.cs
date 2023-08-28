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
            var student = new StudentDetail();
            bool loop = true;
            Console.WriteLine("Enter Student name:");
            student.Name = Console.ReadLine();
            while (loop)
            {
                Console.WriteLine("Enter Registration Number(Roll Number):");
                if (int.TryParse(Console.ReadLine(), out int RegId))
                {
                    student.RegistrationId = RegId;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input! Please enter again");
                }
            }
            loop = true;
            while (loop)
            {
                Console.WriteLine("Enter Student date of birth:");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                {
                    student.DateOfBirth = dateOfBirth;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input! Please enter again");
                }
            }
            loop = true;
            while (loop)
            {
                Console.WriteLine("Enter Student Gender (Male/Female)(Case-Sensitive!):");
                if (Enum.TryParse<Gender>(Console.ReadLine(), out Gender sgender))
                {
                    student.Gender = sgender;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input! Please enter again");
                }
            }
            loop = true;

            Console.WriteLine("Enter Student Address:");
            student.Address = Console.ReadLine();

            while (loop)
            {
                Console.WriteLine("Enter Student Contact Number:");
                if (long.TryParse(Console.ReadLine(), out long contactNumber))
                {
                    student.ContactNumber = contactNumber;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input! Please enter again");
                }
            }
            _studentservice.AddStudent(student);
            Console.WriteLine("Student Added successfully");
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }

        public StudentDetail FindStudent()
        {
            StudentDetail student;
            while (true)
            {
                Console.WriteLine("How would you like search for the student?");
                Console.WriteLine("1. using Student Id");
                Console.WriteLine("2. using Registration Id");
                Console.WriteLine("3. using Name");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out int choice);
                bool loop = true;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Id of the Student:");
                        while (loop)
                        {
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                StudentDetail _student = _studentservice.GetStudentdetails(studentId);
                                student =  _student ;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Registration Id of the Student:");
                        while (loop)
                        {
                            if (int.TryParse(Console.ReadLine(), out int studentRegId))
                            {
                                var _student = _studentservice.GetAllStudents().Where(student=>student.RegistrationId == studentRegId).SingleOrDefault();
                                student = _student;
                                loop = false;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Name of the Student:");
                        string name = Console.ReadLine();
                        IEnumerable<StudentDetail> students = _studentservice.GetAllStudents().Where(student => student.Name == name);

                        foreach (StudentDetail _student in students)
                            DisplayStudent(_student);
                        

                        while (loop)
                        {
                            Console.WriteLine("Enter Id of the Student to selected:");
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                loop = false;
                                student = _studentservice.GetStudentdetails(studentId);
                                if(student == null) { 
                                    Console.WriteLine("Student not Found!");
                                    loop = true;
                                }
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid Input! Please try again");
                        Console.ReadKey();
                        break;
                }

            }
            return student;
        }

        public void DisplayStudent(StudentDetail student)
        {
            Console.WriteLine($"Student Id: {student.Id}");
            Console.WriteLine($"Student Registration Id: { student.RegistrationId}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Date of Birth: {student.DateOfBirth}");
            Console.WriteLine($"Student Contact Number: {student.ContactNumber}");
            Console.WriteLine($"Student Gender: {student.Gender}");
            Console.WriteLine($"Student Address: {student.Address}");
        }

        public void ShowStudentDetails(int studentid)
        {
            Console.Clear();
            var student = _studentservice.GetStudentdetails(studentid);
            DisplayStudent(student);
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }

        public void ShowAllStudents()
        {
            Console.Clear();
            foreach (var student in _studentservice.GetAllStudents())
            {
            DisplayStudent(student);
            }
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;
        }

        public void UpdateStudent()
        {
            Console.Clear();
                var existingStudent = FindStudent();

                if (existingStudent != null)
                {
                    var student = new StudentDetail();
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Detail of Student to be Updated:");
                        Console.WriteLine("1. Registration Id");
                        Console.WriteLine("2. Name");
                        Console.WriteLine("3. Date of Birth");
                        Console.WriteLine("4. Gender");
                        Console.WriteLine("5. Address");
                        Console.WriteLine("6. Contact Number");
                        Console.Write("Enter your choice: ");

                        int.TryParse(Console.ReadLine(), out int choice);
                        bool loop = true;
                        switch (choice)
                        {
                            case 1:
                                while (loop)
                                {
                                    Console.WriteLine("Enter Registration Number(Roll Number):");
                                    if (int.TryParse(Console.ReadLine(), out int RegId))
                                    {
                                        student.RegistrationId = RegId;
                                        loop = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input! Please enter again");
                                    }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Enter Student name:");
                                student.Name = Console.ReadLine();
                                break;
                            case 3:
                                while (loop)
                                {
                                    Console.WriteLine("Enter Student date of birth:");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                                    {
                                        student.DateOfBirth = dateOfBirth;
                                        loop = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input! Please enter again");
                                    }
                                }
                                break;
                            case 4:
                                while (loop)
                                {
                                    Console.WriteLine("Enter Student Gender (Male/Female)(Case-Sensitive!):");
                                    if (Enum.TryParse<Gender>(Console.ReadLine(), out Gender sgender))
                                    {
                                        student.Gender = sgender;
                                        loop = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input! Please enter again");
                                    }
                                }
                                return;
                            case 5:
                                Console.WriteLine("Enter Student Address:");
                                student.Address = Console.ReadLine();
                                return;
                            case 6:
                                while (loop)
                                {
                                    Console.WriteLine("Enter Student Contact Number:");
                                    if (long.TryParse(Console.ReadLine(), out long contactNumber))
                                    {
                                        student.ContactNumber = contactNumber;
                                        loop = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input! Please enter again");
                                    }
                                }
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    _studentservice.UpdateStudent(student);
                    Console.WriteLine("Student updated successfully");
                    Console.WriteLine("Enter any key to go back"); 
                    Console.ReadKey();
                    return;
                }

        }
    }
}
