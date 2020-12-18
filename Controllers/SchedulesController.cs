using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using FedPet.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Proxies;

namespace FedPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        DatabaseContext db;
        public SchedulesController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleObject>>> Get()
        {
            return await db.Schedules.Select(x => new ScheduleObject(x)).ToListAsync();
        }

        // GET api/users/emvoro
        [HttpGet("{Pet_Id}")]
        public async Task<ActionResult<ScheduleObject>> Get(int pet_Id)
        {
            List<Schedule> schedules = await db.Schedules.ToListAsync();
            ScheduleObject schedule = schedules.Select(x => new ScheduleObject(x)).Where(x => x.Pet_Id == pet_Id).FirstOrDefault();
            if (schedule == null)
                return NotFound();
            return new ObjectResult(schedule);
        }
/*
        //GET api/users/pets
        [HttpGet("GetPets/{login}")]
        public async Task<ActionResult<ScheduleObject>> GetPets(string login)
        {
            List<Owner> owners = await db.Owners.ToListAsync();
            Owner owner = owners.Where(x => x.Login == login).FirstOrDefault();
            List<Pet> pets = await db.Pets.ToListAsync();
            IEnumerable<PetObject> petObjects = pets.Select(x => new PetObject(x));

            if (petObjects == null)
                return NotFound();
            return new ObjectResult(petObjects.Where(x => x.Owner_Login == login).AsEnumerable());
        }
*/
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Schedule>> Post(Schedule schedule)
        {
            if (schedule == null)
            {
                return BadRequest();
            }

            db.Schedules.Add(schedule);
            await db.SaveChangesAsync();
            return Ok(schedule);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Schedule>> Put(Schedule schedule)
        {
            if (schedule == null)
            {
                return BadRequest();
            }
            if (!db.Schedules.Any(x => x.Pet_Id == schedule.Pet_Id))
            {
                return NotFound();
            }

            db.Update(schedule);
            await db.SaveChangesAsync();
            return Ok(schedule);
        }

        // DELETE api/users/5
        [HttpDelete("{login}")]
        public async Task<ActionResult<Schedule>> Delete(int pet_Id)
        {
            Schedule schedule = db.Schedules.FirstOrDefault(x => x.Pet_Id == pet_Id);
            if (schedule == null)
            {
                return NotFound();
            }
            db.Schedules.Remove(schedule);
            await db.SaveChangesAsync();
            return Ok(schedule);
        }
    }
}
