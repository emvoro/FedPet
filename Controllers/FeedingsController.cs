using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using FedPet.Objects;
using Microsoft.EntityFrameworkCore;

namespace FedPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingsController : ControllerBase
    {
        DatabaseContext db;
        public FeedingsController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedingObject>>> Get()
        {
            return await db.Feedings.Select(x => new FeedingObject(x)).ToListAsync();
        }

        // GET api/feedings/1
        [HttpGet("{Pet_Id}")]
        public async Task<ActionResult<FeedingObject>> Get(int pet_Id)
        {
            List<Feeding> feedings = await db.Feedings.ToListAsync();
            FeedingObject feeding = feedings.Select(x => new FeedingObject(x)).Where(x => x.Pet_Id == pet_Id).FirstOrDefault();
            if (feeding == null)
                return NotFound();
            return new ObjectResult(feeding);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Feeding>> Post(Feeding feeding)
        {
            if (feeding == null)
            {
                return BadRequest();
            }

            db.Feedings.Add(feeding);
            await db.SaveChangesAsync();
            return Ok(feeding);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Feeding>> Put(Feeding feeding)
        {
            if (feeding == null)
            {
                return BadRequest();
            }
            if (!db.Feedings.Any(x => x.Pet_Id == feeding.Pet_Id))
            {
                return NotFound();
            }

            db.Update(feeding);
            await db.SaveChangesAsync();
            return Ok(feeding);
        }

        // DELETE api/users/5
        [HttpDelete("{Pet_Id}")]
        public async Task<ActionResult<Feeding>> Delete(int pet_Id)
        {
            Feeding feeding = db.Feedings.FirstOrDefault(x => x.Pet_Id == pet_Id);
            if (feeding == null)
            {
                return NotFound();
            }
            db.Feedings.Remove(feeding);
            await db.SaveChangesAsync();
            return Ok(feeding);
        }
    }
}
