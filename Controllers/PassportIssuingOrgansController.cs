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
    public class PassportIssuingOrgansController : ControllerBase
    {
        DatabaseContext db;
        public PassportIssuingOrgansController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassportIssuingOrganObject>>> Get()
        {
            return await db.PassportIssuingOrgans.Select(x => new PassportIssuingOrganObject(x)).ToListAsync();
        }

        // GET api/vetpassports/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<PassportIssuingOrganObject>> Get(int id)
        {
            List<PassportIssuingOrgan> passportIssuings = await db.PassportIssuingOrgans.ToListAsync();
            PassportIssuingOrganObject passportIssuing = passportIssuings.Select(x => new PassportIssuingOrganObject(x)).Where(x => x.Id == id).FirstOrDefault();
            if (passportIssuing == null)
                return NotFound();
            return new ObjectResult(passportIssuing);
        }

        // POST api/pets
        [HttpPost]
        public async Task<ActionResult<PassportIssuingOrgan>> Post(PassportIssuingOrgan passportIssuing)
        {
            if (passportIssuing == null)
            {
                return BadRequest();
            }

            db.PassportIssuingOrgans.Add(passportIssuing);
            await db.SaveChangesAsync();
            return Ok(passportIssuing);
        }

        // PUT api/pets/
        [HttpPut]
        public async Task<ActionResult<PassportIssuingOrgan>> Put(PassportIssuingOrgan passportIssuing)
        {
            if (passportIssuing == null)
            {
                return BadRequest();
            }
            if (!db.PassportIssuingOrgans.Any(x => x.Id == passportIssuing.Id))
            {
                return NotFound();
            }

            db.Update(passportIssuing);
            await db.SaveChangesAsync();
            return Ok(passportIssuing);
        }

        // DELETE api/pets/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PassportIssuingOrgan>> Delete(int id)
        {
            PassportIssuingOrgan passportIssuing = db.PassportIssuingOrgans.FirstOrDefault(x => x.Id == id);
            if (passportIssuing == null)
            {
                return NotFound();
            }
            db.PassportIssuingOrgans.Remove(passportIssuing);
            await db.SaveChangesAsync();
            return Ok(passportIssuing);
        }
    }
}
