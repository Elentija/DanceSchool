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
            var coaches = await context.Coaches.ToListAsync();
            return Ok(coaches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coach = await context.Coaches.FirstOrDefaultAsync(a => a.Id == id);
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
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var coach = new Coach{ Id = id };
            context.Coaches.Remove(coach);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
