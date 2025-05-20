using DivToHours.Core.Dto;
using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Service
{
    public interface IUserService
    {
        List<User> GetAll();
        void AddUser(User user);
        User GetById(int id);
        void DeleteUser(int id);
        User Login(string email, string password);
        User SignUp(string name, string email, string password);
        void AddTestToUser(int userId, string subject);
        void AddStudentToUser(int userId, string name, string tz);
        List<StudentDto> GetStudentsByUserId(int userId);
        List<TestGroupDto> GetTestGroupsByUserId(int userId);

    }
}
