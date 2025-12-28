using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MelodyTrack.API.Data;
using MelodyTrack.API.Models;

namespace MelodyTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly MelodyDbContext _context;
        public EventsController(MelodyDbContext context) => _context = context;

        // Отримати всі події
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents() => await _context.Events.ToListAsync();

        // БІЗНЕС-ЛОГІКА: Отримати афішу майбутніх подій
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<Event>>> GetUpcomingEvents()
        {
            return await _context.Events
                .Where(e => e.EventDate >= DateTime.Now)
                .OrderBy(e => e.EventDate)
                .ToListAsync();
        }
    }
}