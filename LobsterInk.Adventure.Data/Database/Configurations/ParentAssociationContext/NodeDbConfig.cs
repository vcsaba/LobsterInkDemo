using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities.ParentAssociation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations.ParentAssociationContext
{
    public class NodeDbConfig : IEntityTypeConfiguration<ParentAssociationNodeEntity>
    {
        public void Configure(EntityTypeBuilder<ParentAssociationNodeEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
