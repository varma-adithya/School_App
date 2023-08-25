using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ConsoleApp.UI
{
    public interface IStudentPage
    {
        void AddStudent();
        void ShowStudentDetails(int studentid);
        void ShowAllStudents();
        void SubMenu();
        void UpdateStudent();
    }
}
