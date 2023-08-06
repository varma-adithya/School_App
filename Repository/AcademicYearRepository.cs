using School_App.Models;

namespace School_App.Repository
{
    public class AcademicYearRepository
    {
        public AcademicYearRepository()
        {
        }

        public void Create(AcademicYear academicYear)
        {
            using (var context = new SchoolDbContext())
            {
                context.AcademicYears.Add(academicYear);
                context.SaveChanges();
            }
        }

        public AcademicYear Read(int academicYearId)
        {
            using var context = new SchoolDbContext();
            var existing = context.AcademicYears.Find(academicYearId);
            if (existing == null)
            {
                throw new Exception("AcademicYear entry not found");
            }

            return existing;
        }

        public void Update(AcademicYear academicYear)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.AcademicYears.Find(academicYear.Id);
                if (existing == null)
                {
                    throw new Exception("AcademicYear entry not found");
                }

                existing.StartYear = academicYear.StartYear;
                existing.EndYear = academicYear.EndYear;

                context.SaveChanges();
            }
        }

        public void Delete(int academicYearId)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.AcademicYears.Find(academicYearId);
                if (existing == null)
                {
                    throw new Exception("AcademicYear entry not found");
                }

                context.AcademicYears.Remove(existing);

                context.SaveChanges();
            }
        }
    }
}
