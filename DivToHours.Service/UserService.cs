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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITestRepository _testRepository;
        public UserService(IUserRepository userRepository,ITestRepository testRepository)
        {
            _userRepository = userRepository;
            _testRepository = testRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetList();
        }
        public void AddUser(User user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Tests = new List<Test>()
            };

            _userRepository.Add(newUser);
        }
        public User GetById(int id)
        {
            return _userRepository.UserById(id);
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        public User Login(string email, string password) // ✅ מימוש הפונקציה
        {
            return _userRepository.Login(email, password);
        }
        public User SignUp(string name, string email, string password)
        {
            // בדיקה אם המשתמש כבר קיים על פי האימייל
            var existingUser = _userRepository.GetList().FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return null; // המשתמש כבר קיים
            }

            // יצירת משתמש חדש אם לא קיים

            var newUser = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Tests = new List<Test>()
            };

            // הוספת המשתמש למאגר
            _userRepository.SignUp(newUser);

            return newUser;
        }
        public void AddTestToUser(int userId, string subject)
        {
            // מחפש את המשתמש לפי ה-ID
            var user = _userRepository.UserById(userId);
            if (user != null)
            {
                // יצירת מבחן חדש עם ה-Subject שנשלח
                var newTest = new Test
                {
                    Subject = subject,
                    User = user  // קשר את המבחן למשתמש
                };

                // שולח ל-Repository את ההוספה של המבחן למשתמש
                _userRepository.AddTestToUser(userId, newTest);
            }
        }
        
        public void AddStudentToUser(int userId, string name, string tz)
        {
            // מחפש את המשתמש לפי ה-ID
            var user = _userRepository.UserById(userId);
            if (user != null)
            {
                // יצירת מבחן חדש עם ה-Subject שנשלח
                var newStudent = new Student
                {
                    Name= name,
                    Tz= tz,
                    User = user  // קשר את המבחן למשתמש
                };

                // שולח ל-Repository את ההוספה של המבחן למשתמש
                _userRepository.AddStudentToUser(userId, newStudent);
            }
        }
        public List<StudentDto> GetStudentsByUserId(int userId)
        {
            var students = _userRepository.GetStudentsByUserId(userId);
            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Tz = s.Tz
            }).ToList();
        }
        public List<TestGroupDto> GetTestGroupsByUserId(int userId)
        {
            var tests = _userRepository.GetTestsByUserId(userId);

            // אלגוריתם לקיבוץ מבחנים כך שלא יהיו עם תלמידים משותפים
            List<TestGroupDto> testGroups = new List<TestGroupDto>();
            HashSet<int> usedStudents = new HashSet<int>();

            while (tests.Any())
            {
                var group = new List<TestDto>();
                var remainingTests = new List<Test>();

                foreach (var test in tests)
                {
                    var studentIds = test.StudentTests.Select(st => st.Student.Id).ToHashSet();

                    if (!studentIds.Overlaps(usedStudents))
                    {
                        group.Add(new TestDto
                        {
                            Id = test.Id,
                            Subject = test.Subject
                        });

                        usedStudents.UnionWith(studentIds);
                    }
                    else
                    {
                        remainingTests.Add(test);
                    }
                }

                testGroups.Add(new TestGroupDto { Tests = group });
                tests = remainingTests;
                usedStudents.Clear();
            }

            return testGroups;
        }
        
    }
}
