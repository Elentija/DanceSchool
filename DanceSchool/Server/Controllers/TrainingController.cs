using System.Linq;
using System.Threading.Tasks;
using DanceSchool.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanceSchool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly DanceSchoolContext context;
        public TrainingController(DanceSchoolContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllTrainings()
        {
            var trainings = await context.Trainings.ToListAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            if (!context.Trainings.Any(i => i.Id == id))
                return NotFound();

            var training = await context.Trainings
                .FirstAsync(a => a.Id == id);
            
            return Ok(training);
        }


        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddNewTraining(Training training)
        {
            context.Add(training);
            await context.SaveChangesAsync();
            return Ok(training.Id);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateTraininghDate(Training training)
        {
            context.Entry(training).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            if (!context.Trainings.Any(i => i.Id == id))
                return NotFound();

            var training = new Training { Id = id };
            context.Trainings.Remove(training);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
