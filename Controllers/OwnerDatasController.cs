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
    public class OwnerDatasController : ControllerBase
    {
        DatabaseContext db;
        public OwnerDatasController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDataObject>>> Get()
        {
            return await db.OwnerDatas.Select(x => new OwnerDataObject(x)).ToListAsync();
        }

        // GET api/feedings/1
        [HttpGet("{Owner_Login}")]
        public async Task<ActionResult<OwnerDataObject>> Get(string login)
        {
            List<OwnerData> owners = await db.OwnerDatas.ToListAsync();
            OwnerDataObject owner = owners.Select(x => new OwnerDataObject(x)).Where(x => x.Owner_Login == login).FirstOrDefault();
            if (owner == null)
                return NotFound();
            return new ObjectResult(owner);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<OwnerData>> Post(OwnerData owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            db.OwnerDatas.Add(owner);
            await db.SaveChangesAsync();
            return Ok(owner);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<OwnerData>> Put(OwnerData owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }
            if (!db.OwnerDatas.Any(x => x.Owner_Login == owner.Owner_Login))
            {
                return NotFound();
            }

            db.Update(owner);
            await db.SaveChangesAsync();
            return Ok(owner);
        }

        // DELETE api/users/5
        [HttpDelete("{Owner_Login}")]
        public async Task<ActionResult<OwnerData>> Delete(string login)
        {
            OwnerData owner = db.OwnerDatas.FirstOrDefault(x => x.Owner_Login == login);
            if (owner == null)
            {
                return NotFound();
            }
            db.OwnerDatas.Remove(owner);
            await db.SaveChangesAsync();
            return Ok(owner);
        }
    }
}
