using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations
{
    public class AdventureDbConfig : IEntityTypeConfiguration<AdventureEntity>
    {
        public void Configure(EntityTypeBuilder<AdventureEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
