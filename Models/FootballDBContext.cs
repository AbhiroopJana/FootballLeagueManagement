using Microsoft.EntityFrameworkCore;

namespace FootballLeagueManagement.Models
{
    public class FootballDBContext:DbContext
    {
        public FootballDBContext(DbContextOptions<FootballDBContext> options) : base(options) { }

        public DbSet<FootballLeague> FootballLeagues { get;set; }
    }
}
