using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations
{
    public class GameStepDbConfig : IEntityTypeConfiguration<GameStepEntity>
    {
        public void Configure(EntityTypeBuilder<GameStepEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(y => y.SelectedTime)
                .HasValueGenerator<InsertedDateTimeGenerator>()
                .ValueGeneratedOnAdd();

            builder.HasOne(y => y.Game)
                .WithMany(y => y.Steps)
                .HasForeignKey(y => y.GameId);
        }
    }
}
