using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Connections
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            }
        }


        public DbSet<Person> Person { get; set; }
        public DbSet<Practice> Practice { get; set; }
    }
}