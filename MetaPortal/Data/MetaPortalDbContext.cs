using MetaPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace MetaPortal.Data
{
    public class MetaPortalDbContext : DbContext
    {
        public MetaPortalDbContext(DbContextOptions options) : 
            base(options)
        {
                
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
