using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations
{
    public class GameDbConfig : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(y => y.SessionId).IsUnique();

            builder.HasOne(y => y.Adventure)
                .WithMany(y => y.Games)
                .HasForeignKey(y => y.AdventureId);
        }
    }
}
