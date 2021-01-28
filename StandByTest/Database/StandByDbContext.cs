using Microsoft.EntityFrameworkCore;
using StandByTest.Database.Configuration;
using StandByTest.Models;

namespace StandByTest.Database {
    public class StandByDbContext: DbContext {

        public DbSet<Cliente> Clientes { get; set; }

        public StandByDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}
