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
    public class FeedersController : ControllerBase
    {
        DatabaseContext db;
        public FeedersController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<FeederObject>>> GetAll()
        {
            return await db.Feeders.Select(x => new FeederObject(x)).ToListAsync();
        }

        // GET api/users/emvoro
        [HttpGet("{Pet_Id}")]
        public async Task<ActionResult<FeederObject>> Get(int pet_Id)
        {
            List<Feeder> feeders = await db.Feeders.ToListAsync();
            FeederObject feeder = feeders.Select(x => new FeederObject(x)).Where(x => x.Pet_Id == pet_Id).FirstOrDefault();
            if (feeder == null)
                return NotFound();
            return new ObjectResult(feeder);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Feeder>> Post(Feeder feeder)
        {
            if (feeder == null)
            {
                return BadRequest();
            }

            db.Feeders.Add(feeder);
            await db.SaveChangesAsync();
            return Ok(feeder);
        }


        // PUT api/feeders/
        [HttpPut]
        public async Task<ActionResult<Feeder>> Put(Feeder feeder)
        {
            if (feeder == null)
            {
                return BadRequest();
            }
            if (!db.Feeders.Any(x => x.Pet_Id == feeder.Pet_Id))
            {
                return NotFound();
            }

            db.Update(feeder);
            await db.SaveChangesAsync();
            return Ok(feeder);
        }

        // DELETE api/feeders/11
        [HttpDelete("{pet_id}")]
        public async Task<ActionResult<Feeder>> Delete(int pet_id)
        {
            Feeder feeder = db.Feeders.FirstOrDefault(x => x.Pet_Id == pet_id);
            if (feeder == null)
            {
                return NotFound();
            }
            db.Feeders.Remove(feeder);
            await db.SaveChangesAsync();
            return Ok(feeder);
        }
    }
}
