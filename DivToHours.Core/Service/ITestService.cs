using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Service
{
    public interface ITestService
    {
        List<Test> GetAll();
        List<Test> GetTestsByUserId(int userId);
    }
}
