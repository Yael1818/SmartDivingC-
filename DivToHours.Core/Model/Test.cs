using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Model
{
    public class Test
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public User User { get; set; }
        public ICollection<StudentTest> StudentTests { get; set; }
    }
}
