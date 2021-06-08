using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Models
{
    public class pepsContext : DbContext
    {
        public pepsContext(DbContextOptions<pepsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Peps> People { get; set; }
    }
}
