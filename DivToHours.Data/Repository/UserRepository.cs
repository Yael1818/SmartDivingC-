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
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetList()
        {
            return _context.User.ToList();
        }
        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
        public User UserById(int id) 
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }
        public void Delete(int id) 
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }
        public User Login(string email, string password) 
        {
            return _context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public void SignUp(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
        public void AddTestToUser(int userId, Test test)
        {
           
            var user = _context.User.Include(u => u.Tests).FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
               
                user.Tests.Add(test);

               
                _context.SaveChanges();
            }
        }
        public void AddStudentToUser(int userId, Student student)
        {
          
            var user = _context.User.Include(u => u.Students).FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
               
                user.Students.Add(student);

                
                _context.SaveChanges();
            }
        }
        public List<Student> GetStudentsByUserId(int userId)
        {
            return _context.Student
                .Where(s => s.User.Id == userId)
                .ToList();
        }
        public List<Test> GetTestsByUserId(int userId)
        {
            return _context.Test
                .Include(t => t.StudentTests)
                .ThenInclude(st => st.Student)
                .Where(t => t.User.Id == userId)
                .ToList();
        }

    }
}
