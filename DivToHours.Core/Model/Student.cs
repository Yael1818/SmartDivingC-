using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<StudentTest> StudentTests { get; set; }
    }
}
