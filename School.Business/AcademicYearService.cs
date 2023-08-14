using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Data.Repository;

namespace School.Business
{
    public class AcademicYearService
    {

        private readonly IRepository<AcademicYear> _repository;

        public AcademicYearService(IRepository<AcademicYear> repository)
        {
            _repository = repository;
        }

        public void AddAcademicYear(AcademicYear academicYear) 
            => _repository.Add(academicYear);

        public void UpdateAcademicYear(AcademicYear academicYear)
            => _repository.Update(academicYear);

        public AcademicYear GetAcademicYear(int id)
            => _repository.GetById(id);
    }
}
