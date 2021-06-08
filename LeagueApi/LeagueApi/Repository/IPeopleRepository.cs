using LeagueApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Repository
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Peps>> Get();
        Task<Peps> Get(int id);
        Task<Peps> Create(Peps peps);
        Task Update(Peps peps);
        Task Delete(int id);
    }
}
