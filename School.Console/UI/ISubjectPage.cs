using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ConsoleApp.UI
{
    public interface ISubjectPage
    {
        void AddSubject();
        void ShowSubjectDetails(int subjectid);
        void ShowAllSubjects();
        void SubMenu();
        void UpdateSubject();
    }
}
