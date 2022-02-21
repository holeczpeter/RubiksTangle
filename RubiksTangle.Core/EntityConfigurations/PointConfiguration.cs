using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RubiksTangle.Core.Entities;

namespace RubiksTangle.Core.EntityConfigurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder
                .HasKey(x => x.Id);

        }
    }
}
