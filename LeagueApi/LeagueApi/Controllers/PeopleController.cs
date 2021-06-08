using LeagueApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueApi.Models;

namespace LeagueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        [HttpGet]
        public async Task <IEnumerable<Peps>> GetPeople()
        {
            return await _peopleRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Peps>> GetPeople(int id)
        {
            return await _peopleRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Peps>> PostPeople([FromBody] Peps peps)
        {
            var newPeps = await _peopleRepository.Create(peps);
            return CreatedAtAction(nameof(GetPeople), new { id = newPeps.id},newPeps);
        }

        [HttpPut]
        public async Task<ActionResult> PutPeople(int id, [FromBody] Peps peps)
        {
            if (id != peps.id)
            {
                return BadRequest();
            }
            await _peopleRepository.Update(peps);

            return NoContent();
        }
        [HttpDelete]

        public async Task<ActionResult> DeletePeople(int id)
        {
            var peopleToDelete = await _peopleRepository.Get(id);
            if (peopleToDelete ==null)
            {
                return NotFound();
            }
            await _peopleRepository.Delete(peopleToDelete.id);
            return NoContent();
        }
    }
}
