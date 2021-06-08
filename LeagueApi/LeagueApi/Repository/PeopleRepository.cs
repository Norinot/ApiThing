using LeagueApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly pepsContext _context;
        public PeopleRepository(pepsContext context)
        {
            _context = context;
        }

        public async Task<Peps> Create(Peps peps)
        {
            _context.People.Add(peps);
            await _context.SaveChangesAsync();

            return peps;
        }

        public async Task Delete(int id)
        {
            var pepsToDelete = await _context.People.FindAsync(id);
            _context.People.Remove(pepsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Peps>> Get()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Peps> Get(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task Update(Peps peps)
        {
            _context.Entry(peps).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
