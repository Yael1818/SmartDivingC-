using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Repository
{
    public interface IUserRepository
    {
        List<User> GetList();
        void Add(User user);
        User UserById(int id);
        void Delete(int id);
        User Login(string email, string password);
        void SignUp(User user);
        void AddTestToUser(int userId, Test test);
        void AddStudentToUser(int userId, Student student);
        List<Student> GetStudentsByUserId(int userId);
        List<Test> GetTestsByUserId(int userId);
    }
}
