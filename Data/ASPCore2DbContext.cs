using ASPCore2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCore2.Data
{
    public class ASPCore2DbContext : DbContext
    {
        public ASPCore2DbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}