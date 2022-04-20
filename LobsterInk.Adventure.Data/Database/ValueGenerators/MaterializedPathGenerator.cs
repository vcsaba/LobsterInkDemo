using LobsterInk.Adventure.Data.Entities.MaterializedPath;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LobsterInk.Adventure.Data.Database.ValueGenerators
{
    public class MaterializedPathGenerator : ValueGenerator
    {
        protected const char _separator = '/';

        public override bool GeneratesTemporaryValues => false;

        protected override object? NextValue(EntityEntry entry)
        {
            var entity = entry.Entity as MaterializedPathNodeEntity;
            var dbContext = entry.Context as LobsterInkContext;

            var nextValue = entity.ParentId;
            if (nextValue != null)
            {
                var parent = dbContext.MaterializedPathNodeEntities.FirstOrDefault(y => y.Id.Equals(nextValue));
                nextValue = parent.ParentPath + _separator + nextValue;
            }

            return nextValue?.TrimStart(_separator);
        }
    }
}
