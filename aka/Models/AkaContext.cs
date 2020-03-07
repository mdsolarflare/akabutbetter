using Microsoft.EntityFrameworkCore;

namespace akabutbetter.Models
{
    public class AkaContext : DbContext
    {
        public AkaContext(DbContextOptions<AkaContext> options)
            : base(options)
        {
        }

        public DbSet<Shortlink> Shortlinks { get; set; }
    }
}