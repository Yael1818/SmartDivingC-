using DivToHours.Core.Model;
using DivToHours.Core.Service;
using DivToHours.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivToHours.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return _testService.GetAll();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("getByuser/{userId}")]
        public IActionResult GetTestsByUserId(int userId)
        {
            // מחזיר את המבחנים ששייכים למשתמש עם ה-userId הנתון
            var tests = _testService.GetTestsByUserId(userId);

            if (tests == null || !tests.Any())
                return NotFound($"No tests found for user with ID {userId}");

            return Ok(tests);
        }

    }
}
