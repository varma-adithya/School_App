using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public class AcademicYearService
    {

        private readonly IRepository<AcademicYear> _repository;

        public AcademicYearService()
        {
            _repository = new Repository<AcademicYear>(new SchoolDbContext(@"Data Source=C:/Users/abhilashgr/Documents/GitHub/School_App/School.Data/school_database.db"));
        }

        public void AddAcademicYear(AcademicYear academicYear) 
            => _repository.Add(academicYear);

        public IEnumerable<AcademicYear> GetAllAcademicYear()
            => _repository.GetAll().ToList();

        public void UpdateAcademicYear(AcademicYear academicYear)
            => _repository.Update(academicYear);

        public AcademicYear GetAcademicYear(int id)
            => _repository.GetById(id);
    }
}
