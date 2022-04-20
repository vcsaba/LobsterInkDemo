using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LobsterInk.Adventure.Data.Database.ValueGenerators
{
    internal class NestedSetSideValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object? NextValue(EntityEntry entry)
        {
            // TODO
            return 5;
        }
    }
}
