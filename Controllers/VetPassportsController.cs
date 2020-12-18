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
    public class VetPassportsController : ControllerBase
    {
        DatabaseContext db;
        public VetPassportsController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetPassportObject>>> Get()
        {
            return await db.VetPassports.Select(x => new VetPassportObject(x)).ToListAsync();
        }

        // GET api/vetpassports/1
        [HttpGet("{Pet_Id}")]
        public async Task<ActionResult<VetPassportObject>> Get(int pet_id)
        {
            List<VetPassport> vetPassports = await db.VetPassports.ToListAsync();
            VetPassportObject vetPassport = vetPassports.Select(x => new VetPassportObject(x)).Where(x => x.Pet_Id == pet_id).FirstOrDefault();
            if (vetPassport == null)
                return NotFound();
            return new ObjectResult(vetPassport);
        }

        // POST api/pets
        [HttpPost]
        public async Task<ActionResult<VetPassport>> Post(VetPassport vetPassport)
        {
            if (vetPassport == null)
            {
                return BadRequest();
            }

            db.VetPassports.Add(vetPassport);
            await db.SaveChangesAsync();
            return Ok(vetPassport);
        }

        // PUT api/pets/
        [HttpPut]
        public async Task<ActionResult<VetPassport>> Put(VetPassport vetPassport)
        {
            if (vetPassport == null)
            {
                return BadRequest();
            }
            if (!db.VetPassports.Any(x => x.Pet_Id == vetPassport.Pet_Id))
            {
                return NotFound();
            }

            db.Update(vetPassport);
            await db.SaveChangesAsync();
            return Ok(vetPassport);
        }

        // DELETE api/pets/5
        [HttpDelete("{Pet_Id}")]
        public async Task<ActionResult<VetPassport>> Delete(int pet_id)
        {
            VetPassport vetPassport = db.VetPassports.FirstOrDefault(x => x.Pet_Id == pet_id);
            if (vetPassport == null)
            {
                return NotFound();
            }
            db.VetPassports.Remove(vetPassport);
            await db.SaveChangesAsync();
            return Ok(vetPassport);
        }
    }
}
