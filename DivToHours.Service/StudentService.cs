using DivToHours.Core.Dto;
using DivToHours.Core.Model;
using DivToHours.Core.Repository;
using DivToHours.Core.Service;
using DivToHours.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Service
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetList();
        }
        public void AddTestToStudent(int studentId, int testId)
        {
            _studentRepository.AddTestToStudent(studentId, testId);
        }
        public Student GetStudentWithTests(int studentId)
        {
            return _studentRepository.GetStudentWithTests(studentId);
        }
        public List<TestDto> GetTestsByStudentId(int studentId)
        {
            var student = _studentRepository.GetStudentWithTests(studentId);
            if (student == null) return new List<TestDto>();

            return student.StudentTests.Select(st => new TestDto
            {
                Id = st.Test.Id,
                Subject = st.Test.Subject
            }).ToList();
        }
        public Student GetStudentByTz(string tz)
        {
            return _studentRepository.GetStudentByTz(tz);
        }

    }

}
