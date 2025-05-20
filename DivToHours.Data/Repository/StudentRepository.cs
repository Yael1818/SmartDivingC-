using DivToHours.Core.Model;
using DivToHours.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Data.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public List<Student> GetList()
        {
            return _context.Student.ToList();
        }
        public void AddTestToStudent(int studentId, int testId)
        {
            var student = _context.Student.Include(s => s.StudentTests).FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                var test = _context.Test.FirstOrDefault(t => t.Id == testId);
                if (test != null)
                {
                    student.StudentTests.Add(new StudentTest { Student = student, Test = test });
                    _context.SaveChanges();
                }
            }

        }
        public Student GetStudentWithTests(int studentId)
        {
            return _context.Student
                .Include(s => s.StudentTests)  
                    .ThenInclude(st => st.Test) 
                .FirstOrDefault(s => s.Id == studentId);
        }
        public Student GetStudentByTz(string tz)
        {
            return _context.Student.FirstOrDefault(s => s.Tz == tz);
        }



    }
}
