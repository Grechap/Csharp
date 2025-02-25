using APIDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Student.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApiWithDB _context;

        public StudentsController(ApiWithDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Students>> GetStudentByName(string name)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.FirstName == name);

            if (student == null)
            {
                return NotFound(new { message = "Студента с таким именем нет" });
            }

            return student;
        }
    }
}