using Microsoft.EntityFrameworkCore;

namespace akabutbetter.Models
{
    public class ShortlinkContext : DbContext
    {
        public ShortlinkContext(DbContextOptions<ShortlinkContext> options)
            : base(options)
        {
        }

        public DbSet<Shortlink> Shortlinks { get; set; }
    }
}