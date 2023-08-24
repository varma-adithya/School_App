using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public interface IAcademicYearService
    {
        void AddAcademicYear(AcademicYear academicYear);

        IEnumerable<AcademicYear> GetAllAcademicYear();

        void UpdateAcademicYear(AcademicYear academicYear);

        public AcademicYear GetAcademicYear(int id);
	}


	public class AcademicYearService : IAcademicYearService
	{

        private readonly IRepository<AcademicYear> _repository;

        public AcademicYearService(IRepository<AcademicYear> repository)
        {
           _repository = repository;
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
