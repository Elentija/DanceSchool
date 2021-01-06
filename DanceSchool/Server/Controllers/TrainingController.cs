using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceSchool.Shared.Models;
using Microsoft.AspNetCore.Http;
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
            this.context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainings()
        {
            var trainings = await context.Trainings.ToListAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var training = await context.Trainings
                .FirstOrDefaultAsync(a => a.Id == id);
            return Ok(training);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTraining(Training training)
        {
            context.Add(training);
           /* var coach = context.Coaches.FirstOrDefault(x => x.Id == training.Coach.Id);
            coach.Trainings.Add(training);
            context.Update(coach);*/
            await context.SaveChangesAsync();
            return Ok(training.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTraininghDate(Training training)
        {
            context.Entry(training).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = new Training { Id = id };
            context.Trainings.Remove(training);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
