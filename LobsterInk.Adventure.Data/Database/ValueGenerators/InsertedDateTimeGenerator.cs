using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LobsterInk.Adventure.Data.Database.ValueGenerators
{
    public class InsertedDateTimeGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object? NextValue(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
}
