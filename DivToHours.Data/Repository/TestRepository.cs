using DivToHours.Core.Model;
using DivToHours.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Data.Repository
{
    public class TestRepository:ITestRepository
    {
        private readonly DataContext _context;
        public TestRepository(DataContext context)
        {
            _context = context;
        }
        public List<Test> GetList()
        {
            return _context.Test.ToList();
        }
        public List<Test> GetTestsByUserId(int userId)
        {
            // מחפש את כל המבחנים ששייכים למשתמש עם ה-userId הנתון
            return _context.Test.Where(t => t.User.Id == userId).ToList();
        }

        
    }
}
