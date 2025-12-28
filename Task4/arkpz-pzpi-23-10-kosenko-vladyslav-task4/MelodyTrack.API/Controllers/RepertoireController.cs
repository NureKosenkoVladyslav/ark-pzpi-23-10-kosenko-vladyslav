using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MelodyTrack.API.Data;
using MelodyTrack.API.Models;

namespace MelodyTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepertoireController : ControllerBase
    {
        private readonly MelodyDbContext _context;

        public RepertoireController(MelodyDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repertoire>>> GetRepertoire()
        {
            return await _context.Repertoire.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<Repertoire>> PostPiece(Repertoire piece)
        {
            _context.Repertoire.Add(piece);
            await _context.SaveChangesAsync();
            return Ok(piece);
        }
        
        [HttpGet("progress/{studentId}")]
        public async Task<ActionResult> GetRepertoireProgress(int studentId)
        {
            var repertoire = await _context.Repertoire
                .Where(r => r.StudentID == studentId)
                .ToListAsync();

            if (repertoire.Count == 0)
            {
                return Ok(new { message = "Репертуарний план порожній", progress = 0 });
            }

           
            int totalPieces = repertoire.Count;
            int completedPieces = repertoire.Count(r => r.Status == "Вивчено" || r.Status == "Ready");

          
            double progressPercentage = (double)completedPieces / totalPieces * 100;

            return Ok(new
            {
                Total = totalPieces,
                Completed = completedPieces,
                Progress = Math.Round(progressPercentage, 1) + "%"
            });
        }
    }
}