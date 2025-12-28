using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MelodyTrack.API.Data;   
using MelodyTrack.API.Models; 

namespace MelodyTrack.API.Controllers
{

    [Route("api/[controller]")] 
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly MelodyDbContext _context;

        
        public GradesController(MelodyDbContext context)
        {
            _context = context;
        }

     
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        
        
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync(); 

            return Ok(grade);
        }
       
        [HttpGet("average/{studentId}")]
        public async Task<ActionResult<double>> GetAverageGrade(int studentId)
        {
            var grades = await _context.Grades
                .Where(g => g.StudentID == studentId)
                .ToListAsync();

            if (grades.Count == 0) return 0;

            
            double average = grades.Average(g => g.Value);
            return Ok(Math.Round(average, 2));
        }

    }

}