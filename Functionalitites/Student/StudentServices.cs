using System;
using System.Collections.Generic;
using System.Linq;
using School_App.Models;

namespace School_App.Services
{
    internal class StudentServices
    {
        private readonly SchoolDbContext context;

        public StudentServices(SchoolDbContext context)
        {
            this.context = context;
        }

        public void CreateStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public List<Student> AllStudents()
        {
            return context.Students.ToList();
        }


        public Student ReadStudent(int studentId)
        {
            return context.Students.Find(studentId);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            var existingStudent = context.Students.Find(updatedStudent.StudentId);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Class = updatedStudent.Class;
                context.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }




    }
}
