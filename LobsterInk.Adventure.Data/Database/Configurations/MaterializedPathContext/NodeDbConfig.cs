using LobsterInk.Adventure.Data.Database.ValueGenerators;
using LobsterInk.Adventure.Data.Entities.MaterializedPath;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LobsterInk.Adventure.Data.Database.Configurations.MaterializedPathContext
{
    public class NodeDbConfig : IEntityTypeConfiguration<MaterializedPathNodeEntity>
    {
        public void Configure(EntityTypeBuilder<MaterializedPathNodeEntity> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id)
                .HasValueGenerator<GuidGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(y => y.ParentPath)
                .HasValueGenerator<MaterializedPathGenerator>()
                .ValueGeneratedOnAdd();
        }
    }
}
