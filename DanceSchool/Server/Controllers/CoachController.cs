using System.Linq;
using System.Threading.Tasks;
using DanceSchool.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanceSchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly DanceSchoolContext context;
        public CoachController(DanceSchoolContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = await context.Coaches.OrderBy(z => z.LastName).ToListAsync();
            return Ok(coaches);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            if (!context.Coaches.Any(i => i.Id == id))
                return NotFound();

            var coach = await context.Coaches
                .FirstAsync(a => a.Id == id);

            return Ok(coach);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCoach(Coach coach)
        {
            context.Add(coach);
            await context.SaveChangesAsync();
            return Ok(coach.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoachDate(Coach coach)
        {
            context.Entry(coach).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            if (!context.Coaches.Any(i => i.Id == id))
                return NotFound();

            var coach = new Coach{ Id = id };
            context.Coaches.Remove(coach);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
