using Microsoft.EntityFrameworkCore;
using RubiksTangle.Core.Entities;
using RubiksTangle.Core.EntityConfigurations;

namespace RubiksTangle.Core
{
    public class RubikDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Point> Points { get; set; }
        public RubikDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfigurator.ConfigureModelEntities(modelBuilder);
        }
    }
}
