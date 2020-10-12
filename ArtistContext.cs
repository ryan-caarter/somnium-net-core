using Microsoft.EntityFrameworkCore;

namespace somniumAPI.Models
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public DbSet<Artists> TodoItems { get; set; }
    }
}