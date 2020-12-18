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
    public class PetsController : ControllerBase
    {
        DatabaseContext db;
        public PetsController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PetObject>>> Get()
        {
            return await db.Pets.Select(x=>new PetObject(x)).ToListAsync();
        }

        // GET api/pets/5
        [HttpGet("GetPet/{Id}")]
        public async Task<ActionResult<PetObject>> Get(int id)
        {
            List<Pet> pets = await db.Pets.ToListAsync();
            PetObject pet = pets.Select(x => new PetObject(x)).Where(x => x.Id == id).FirstOrDefault();
            if (pet == null)
                return NotFound();
            return new ObjectResult(pet);
        }

        // GET api/pets/getbyowner/emvoro
        [HttpGet("GetByOwner/{Owner_Login}")]
        public async Task<ActionResult<IEnumerable<PetObject>>> GetPets(string owner_Login)
        {
            //return await db.Pets.Select(x => new PetObject(x)).Where(x => x.Owner_Login == owner_Login).AsAsyncEnumerable();
            List<Pet> pets = await db.Pets.ToListAsync();
            IEnumerable<PetObject> petObjects = pets.Select(x => new PetObject(x)); 
            if (petObjects == null)
                return NotFound();
            return new ObjectResult(petObjects.Where(x => x.Owner_Login == owner_Login).AsEnumerable());
        }

        // GET api/owners/emvoro
        [HttpGet("GetFeedingNorm/{id}")]
        public async Task<ActionResult<HealthIndicatorsObject>> GetFeedingNorm(int id)
        {
            List<Pet> pets = await db.Pets.ToListAsync();
            PetObject pet = pets.Select(x => new PetObject(x)).Where(x => x.Id == id).FirstOrDefault();
            List<HealthIndicators> healths = await db.HealthIndicators.ToListAsync();
            HealthIndicatorsObject health = healths.Select(x => new HealthIndicatorsObject(x)).Where(x => x.Pet_Id == pet.Id).FirstOrDefault();
            if (pet == null || health == null)
                return NotFound();
            double norm = 0;
            string message = "";
            if (CountAge(health.DateOfBirth) / 365 < 1)
            {
                message = "Feed your pet 3 times a day.";
                switch (Convert.ToInt32(health.Weight))
                {
                    case 2:
                        {
                            norm = 35;
                            break;
                        }
                    case 3:
                        {
                            norm = 50;
                            break;
                        }
                    case 4:
                        {
                            norm = 70;
                            break;
                        }
                    default:
                        {
                            message = "You need to take your pet to vet as soon as possible!";
                            break;
                        }
                }

            }
            else
            {
                message = "Feed your pet 2 times a day.";
                switch (Convert.ToInt32(health.Weight))
                {
                    case 4:
                        {
                            norm = 40;
                            break;
                        }
                    case 5:
                        {
                            if (health.Pregnancy)
                                norm = 55;
                            else
                                norm = 50;
                            break;
                        }
                    case 6:
                        {
                            if (health.Pregnancy)
                                norm = 12 * health.Weight;
                            else
                                norm = 50;
                            break;
                        }
                    default:
                        {
                            message = "You need to take your pet to vet as soon as possible!";
                            break;
                        }
                }
            }
            Dictionary<double, string> d = new Dictionary<double, string>();
            d.Add(norm, message);
            return new ObjectResult(d);
        }

        static int CountAge(DateTime dateTime)
        {
            return DateTime.Now.Year - dateTime.Year;
        }

        // POST api/pets
        [HttpPost("AddPet")]
        public async Task<ActionResult<Pet>> Post(Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }

            db.Pets.Add(pet);
            await db.SaveChangesAsync();
            return Ok(pet);
        }

        // PUT api/pets/
        [HttpPut("EditPet/{Id}")]
        public async Task<ActionResult<Pet>> Put(int id)
        {
            Pet pet = db.Pets.FirstOrDefault(x => x.Id == id);
            if (pet == null)
            {
                return BadRequest();
            }
            if (!db.Pets.Any(x => x.Id == pet.Id))
            {
                return NotFound();
            }
            db.Update(pet);
            await db.SaveChangesAsync();
            return Ok(pet);
        }

        // DELETE api/pets/deletepet/5
        [HttpDelete("DeletePet/{Id}")]
        public async Task<ActionResult<Pet>> Delete(int id)
        {
            Pet pet = db.Pets.FirstOrDefault(x => x.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            db.Pets.Remove(pet);
            await db.SaveChangesAsync();
            return Ok(pet);
        }
    }
}
