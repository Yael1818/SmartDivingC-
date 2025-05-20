using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Model
{
    public class StudentTest
    {
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public Student Student { get; set; } 

        public int TestsId { get; set; }
        public Test Test { get; set; }
    }
}
