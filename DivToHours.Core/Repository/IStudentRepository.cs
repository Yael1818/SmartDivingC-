using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetList();
        void AddTestToStudent(int studentId, int testId);
        Student GetStudentWithTests(int studentId);
        Student GetStudentByTz(string tz);

    }
}