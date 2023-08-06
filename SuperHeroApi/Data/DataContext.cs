using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
