using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToWatch.Models;

namespace ToWatch.Database
{
    public class WatchContext : IdentityDbContext<AppUser>
    {
        private IConfigurationRoot config;

        public WatchContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(config["ConnectionStrings:WatchContextConnection"]);
        }
    }
}
