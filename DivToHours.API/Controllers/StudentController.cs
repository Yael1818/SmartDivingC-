using DivToHours.Core.Dto;
using DivToHours.Core.Model;
using DivToHours.Core.Service;
using DivToHours.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivToHours.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("{studentId}/addTest/{testId}")]
        public IActionResult AddTestToStudent(int studentId, int testId)
        {
            _studentService.AddTestToStudent(studentId, testId);
            return Ok();
        }
        [HttpGet("{studentId}/tests")]
        public ActionResult<Student> GetStudentWithTests(int studentId)
        {
            var student = _studentService.GetStudentWithTests(studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }
        [HttpGet("{studentId}/testsByStudentId")]
        public ActionResult<List<TestDto>> GetStudentTests(int studentId)
        {
            var tests = _studentService.GetTestsByStudentId(studentId);
            if (tests == null || !tests.Any())
            {
                return NotFound("No tests found for this student.");
            }
            return Ok(tests);
        }
        [HttpGet("byTz/{tz}")]
        public ActionResult<Student> GetStudentByTz(string tz)
        {
            var student = _studentService.GetStudentByTz(tz);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }

    }
}
