using DivToHours.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Core.Repository
{
    public interface ITestRepository
    {
        List<Test> GetList();
        List<Test> GetTestsByUserId(int userId);

    }
}
