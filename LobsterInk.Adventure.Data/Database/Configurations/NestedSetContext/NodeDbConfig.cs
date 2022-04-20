using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities.NestedSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations.NestedSetContext
{
    public class NodeDbConfig : IEntityTypeConfiguration<NestedSetNodeEntity>
    {
        public void Configure(EntityTypeBuilder<NestedSetNodeEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(y => y.Left)
                .HasValueGenerator<NestedSetSideValueGenerator>()
                .ValueGeneratedNever();

            builder.Property(y => y.Right)
                .HasValueGenerator<NestedSetSideValueGenerator>()
                .ValueGeneratedNever();
        }
    }
}
