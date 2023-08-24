using School.Business;
using School.Data.Models;

namespace School.ConsoleApp.UI
{
	public interface IAcademicYearPage
	{
		void AddAcademicYear();
		void ShowAcademicYearDetails(int academicYearId);
		void ShowAllAcademicYears();
		void SubMenu();
		void UpdateAcademicYear();
	}
}