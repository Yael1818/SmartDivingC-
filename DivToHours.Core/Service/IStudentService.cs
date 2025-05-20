using DivToHours.Core.Dto;
using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Service
{
    public interface IStudentService
    {
        List<Student> GetAll();
        void AddTestToStudent(int studentId, int testId);
        Student GetStudentWithTests(int studentId);
        List<TestDto> GetTestsByStudentId(int studentId);
        Student GetStudentByTz(string tz);

    }
}
