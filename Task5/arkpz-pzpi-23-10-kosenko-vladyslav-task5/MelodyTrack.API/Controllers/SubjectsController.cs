using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MelodyTrack.API.Data;
using MelodyTrack.API.Models;

namespace MelodyTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly MelodyDbContext _context;
        public SubjectsController(MelodyDbContext context) => _context = context;

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects() => await _context.Subjects.ToListAsync();

       
        [HttpGet("stats")]
        public async Task<ActionResult> GetSubjectStats()
        {
            var stats = await _context.Subjects
                .Select(s => new {
                    Subject = s.SubjectName,
                    TotalGrades = _context.Grades.Count(g => g.SubjectID == s.SubjectID)
                }).ToListAsync();

            return Ok(stats);
        }
    }
}