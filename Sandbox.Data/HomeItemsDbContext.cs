using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sandbox.Domain.Models;

namespace Sandbox.Data
{
    public class HomeItemsDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly DbContextOptions<HomeItemsDbContext> _options;

        public HomeItemsDbContext(DbContextOptions<HomeItemsDbContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<HomeItem> HomeItems { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
