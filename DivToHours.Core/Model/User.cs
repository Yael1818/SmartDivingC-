using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Test> Tests { get; set; }

        public ICollection<Student> Students { get; set; }
        
    }
}
