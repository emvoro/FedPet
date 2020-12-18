using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using FedPet.Objects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FedPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        DatabaseContext db;
        public StatisticsController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<StatisticsObject>>> GetAll()
        {
            return await db.Statistics.Select(x => new StatisticsObject(x)).ToListAsync();
        }

        public DateTime DeserializeData(DateTime jsonString)
        {
            var obj = JsonConvert.DeserializeObject<DateTime>(jsonString.ToString(),
            new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            return obj;
        }

        // GET api/users/emvoro
        [HttpGet("{Pet_Id}")]
        public async Task<ActionResult<StatisticsObject>> Get(int pet_Id)
        {
            List<Statistics> stats = await db.Statistics.ToListAsync();
            /*for (int i = 0; i < stats.Count; i++)
            {
                stats[i].DateOfFeeding = DeserializeData(stats[i].DateOfFeeding);
            }*/
            IEnumerable<StatisticsObject> statistics = stats
                .Select(x => new StatisticsObject(x))
                .Where(x => x.Pet_Id == pet_Id)
                .OrderBy(x => x.DateOfFeeding);
            if (statistics == null)
                return NotFound();
            return new ObjectResult(statistics);
        }

        [HttpGet("GetAverage/{Pet_Id}")]
        public async Task<ActionResult<StatisticsObject>> GetAverage(int pet_Id)
        {
            List<Statistics> statistics = await db.Statistics.ToListAsync();
            IEnumerable<StatisticsObject> countStatistics = statistics
                .Select(x => new StatisticsObject(x))
                .Where(x => x.Pet_Id == pet_Id);
            if (countStatistics == null)
                return NotFound();
            double o = Math.Truncate(countStatistics
                .Average(x => x.AmountOfFood));
            return new ObjectResult(o);
        }

        [HttpGet("GetMax/{Pet_Id}")]
        public async Task<ActionResult<StatisticsObject>> GetMax(int pet_Id)
        {
            List<Statistics> statistics = await db.Statistics.ToListAsync();
            IEnumerable<StatisticsObject> countStatistics = statistics
                .Select(x => new StatisticsObject(x))
                .Where(x => x.Pet_Id == pet_Id);
            if (countStatistics == null)
                return NotFound();
            double o = Math.Truncate(countStatistics.Max(x => x.AmountOfFood));
            return new ObjectResult(o);
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Statistics>> Post(Statistics statistics)
        {
            if (statistics == null)
            {
                return BadRequest();
            }

            db.Statistics.Add(statistics);
            await db.SaveChangesAsync();
            return Ok(statistics);
        }

/*
        // PUT api/feeders/
        [HttpPut]
        public async Task<ActionResult<Statistics>> Put(Statistics statistics)
        {
            if (statistics == null)
            {
                return BadRequest();
            }
            if (!db.Statistics.Any(x => x.Pet_Id == statistics.Pet_Id))
            {
                return NotFound();
            }

            db.Update(statistics);
            await db.SaveChangesAsync();
            return Ok(statistics);
        }

        // DELETE api/feeders/11
        [HttpDelete("{pet_id}")]
        public async Task<ActionResult<Statistics>> Delete(int pet_id)
        {
            Statistics statistics = db.Statistics.FirstOrDefault(x => x.Pet_Id == pet_id);
            if (statistics == null)
            {
                return NotFound();
            }
            db.Statistics.Remove(statistics);
            await db.SaveChangesAsync();
            return Ok(statistics);
        }
*/    }
}
