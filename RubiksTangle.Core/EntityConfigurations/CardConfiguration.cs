using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RubiksTangle.Core.Entities;

namespace RubiksTangle.Core.EntityConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder
                .HasKey(x => x.Id);
           
            builder
                .HasMany(c => c.Points)
                .WithOne(e => e.Card)
                .HasForeignKey(e => e.CardId);
        }
    }
}
