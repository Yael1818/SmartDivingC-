using DivToHours.Core.Dto;
using DivToHours.Core.Model;
using DivToHours.Core.Service;
using DivToHours.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivToHours.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            return Ok(user);
        }
        

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid user data");

            _userService.AddUser(user);
            return Ok("User added successfully");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound($"User with ID {id} not found");

            _userService.DeleteUser(id);
            return Ok($"User with ID {id} deleted successfully");
        }
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest("Email and Password are required");

            var user = _userService.Login(email,password);
            if (user == null)
                return Unauthorized("Invalid email or password");

            return Ok(new { message = "Login successful", userId = user.Id });
        }
        [HttpPost("signup")]
        public IActionResult SignUp(string name, string email, string password)
        {
            if ( name == null|| email == null|| password == null)
                return BadRequest("Invalid registration data");

            var newUser = _userService.SignUp(name, email, password);

            if (newUser == null)
            {
                return Conflict("User already exists with this email");
            }

            return Ok(new { message = "SignUp successful", userId = newUser.Id });
        }
        [HttpPost("{userId}/addTest")]
        public IActionResult AddTestToUser(int userId,string subject)
        {
            if (string.IsNullOrEmpty(subject))
                return BadRequest("Subject is required");

            _userService.AddTestToUser(userId, subject);
            return Ok("Test added to user successfully");
        }
        [HttpPost("{userId}/addStudent")]
        public IActionResult AddStudentToUser(int userId, string name, string tz)
        {
            if (string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(tz))
                return BadRequest("Subject is required");

            _userService.AddStudentToUser(userId, name, tz);
            return Ok("Test added to user successfully");
        }
        [HttpGet("{userId}/students")]
        public IActionResult GetStudentsByUserId(int userId)
        {
            List<StudentDto> students = _userService.GetStudentsByUserId(userId);

            if (students == null || students.Count == 0)
                return NotFound("No students found for this user.");

            return Ok(students);
        }
        [HttpGet("{userId}/test-groups")]
        public IActionResult GetTestGroupsByUserId(int userId)
        {
            List<TestGroupDto> testGroups = _userService.GetTestGroupsByUserId(userId);

            if (testGroups == null || testGroups.Count == 0)
                return NotFound("No test groups found for this user.");

            return Ok(testGroups);
        }

    }
}

