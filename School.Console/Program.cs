// See https://aka.ms/new-console-template for more information
using School.Business;
using School.Data.Models;
using School.Data.Repository;

Console.WriteLine("Hello, World!");

// CRUD Academic Year
var academicYearService = new AcademicYearService(new Repository<AcademicYear>(null));
academicYearService.AddAcademicYear(new AcademicYear { StartYear = 2023, EndYear = 2024 });