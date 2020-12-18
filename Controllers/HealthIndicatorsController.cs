using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using FedPet.Objects;
using Microsoft.EntityFrameworkCore;
using FedPet.ViewModels;

namespace FedPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthIndicatorsController : ControllerBase
    {
        DatabaseContext db;
        public HealthIndicatorsController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<HealthIndicatorsObject>>> GetAll()
        {
            return await db.HealthIndicators.Select(x => new HealthIndicatorsObject(x)).ToListAsync();
        }

        // GET api/owners/emvoro
        [HttpGet("GetHealth/{id}")]
        public async Task<ActionResult<HealthIndicatorsObject>> GetHealth(int id)
        {
            List<HealthIndicators> healths = await db.HealthIndicators.ToListAsync();
            HealthIndicatorsObject health = healths.Select(x => new HealthIndicatorsObject(x)).Where(x => x.Pet_Id == id).FirstOrDefault();
            if (health == null)
                return NotFound();
            return new ObjectResult(health);
        }



        // POST api/pets
        [HttpPost("AddHealth")]
        public async Task<ActionResult<HealthIndicators>> Post(HealthIndicators health)
        {
            if (health == null)
            {
                return BadRequest();
            }

            db.HealthIndicators.Add(health);
            await db.SaveChangesAsync();
            return Ok(health);
        }


        // PUT api/owners/
        [HttpPut]
        public async Task<ActionResult<HealthIndicators>> Put(HealthIndicators health)
        {
            if (health == null)
            {
                return BadRequest();
            }
            if (!db.HealthIndicators.Any(x => x.Pet_Id == health.Pet_Id))
            {
                return NotFound();
            }

            db.Update(health);
            await db.SaveChangesAsync();
            return Ok(health);
        }

        // DELETE api/users/kolyan
        [HttpDelete("{pet_id}")]
        public async Task<ActionResult<HealthIndicators>> Delete(int pet_Id)
        {
            HealthIndicators health = db.HealthIndicators.FirstOrDefault(x => x.Pet_Id == pet_Id);
            if (health == null)
            {
                return NotFound();
            }
            db.HealthIndicators.Remove(health);
            await db.SaveChangesAsync();
            return Ok(health);
        }
    }
}
