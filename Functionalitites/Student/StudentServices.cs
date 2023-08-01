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

        public int CreateStudent(Student student)
        {
            context.Students.Add(student);
            return context.SaveChanges();
        }

        public List<Student> AllStudents()
        {
            return context.Students.ToList();
        }


        public Student FindStudent(int studentId)
        {
            return context.Students.Find(studentId);
        }

        public int UpdateStudent(Student updatedStudent)
        {
            var existingStudent = context.Students.Find(updatedStudent.StudentId);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Class = updatedStudent.Class;
                return context.SaveChanges();
            }
            else return 0;
        }

        public int DeleteStudent(int studentId)
        {
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                context.Students.Remove(student);
                return context.SaveChanges(); 
            }
            else return 0;
        }




    }
}
