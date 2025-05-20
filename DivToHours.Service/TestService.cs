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
    public class TestService:ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public List<Test> GetAll()
        {
           return _testRepository.GetList();
        }
        public List<Test> GetTestsByUserId(int userId)
        {
           
            return _testRepository.GetTestsByUserId(userId);
        }

    }
}
