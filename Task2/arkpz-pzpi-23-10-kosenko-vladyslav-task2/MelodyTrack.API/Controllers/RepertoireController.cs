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
            return await _context.Repertoires.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<Repertoire>> PostPiece(Repertoire piece)
        {
            _context.Repertoires.Add(piece);
            await _context.SaveChangesAsync();
            return Ok(piece);
        }
    }
}