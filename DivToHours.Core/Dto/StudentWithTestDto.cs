using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Dto
{
    public class StudentWithTestDto
    {
        public int Id { get; set; }
        
        public List<TestDto> Tests { get; set; }
    }
}
