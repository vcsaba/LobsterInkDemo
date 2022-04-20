using LobsterInk.Adventure.Data.Entities.MaterializedPath;
using LobsterInk.Adventure.Data.Entities.ParentAssociation;
using LobsterInk.Adventure.Data.Entities.NestedSet;
using Microsoft.EntityFrameworkCore;
using LobsterInk.Adventure.Data.Entities;

namespace LobsterInk.Adventure.Data.Database
{
    public class LobsterInkContext : DbContext
    {
        public LobsterInkContext(DbContextOptions<LobsterInkContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<ParentAssociationNodeEntity> ParentAssociationNodeEntities { get; set; }

        public virtual DbSet<MaterializedPathNodeEntity> MaterializedPathNodeEntities { get; set; }

        public virtual DbSet<NestedSetNodeEntity> NestedSetNodeEntities { get; set; }

        public virtual DbSet<AdventureEntity> Adventures { get; set; }

        public virtual DbSet<GameEntity> Games { get; set; }

        public virtual DbSet<GameStepEntity> GameSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LobsterInkContext).Assembly);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentAssociationNodeEntity>().HasData(
                new ParentAssociationNodeEntity
                {
                    Id = "f1153d44-513f-43a9-b739-40ebb59b64e1",
                    Message = "Do I want a doughnut?",
                    Details = string.Empty
                },
                new ParentAssociationNodeEntity
                {
                    Id = "ec55ef85-6ea0-4194-a00d-52e0eefbd27c",
                    ParentId = "f1153d44-513f-43a9-b739-40ebb59b64e1",
                    Message = "Do I deserve it?",
                    Details = "YES"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "326a6e1f-d3c0-4294-b756-0577dd745707",
                    ParentId = "f1153d44-513f-43a9-b739-40ebb59b64e1",
                    Message = "Maybe you want an apple?",
                    Details = "NO"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "2859fe39-398e-480a-8bf7-34531e72963d",
                    ParentId = "ec55ef85-6ea0-4194-a00d-52e0eefbd27c",
                    Message = "Is it a good doughnut?",
                    Details = "NO"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "6b446e00-8e80-4404-8789-3c1fde939be8",
                    ParentId = "ec55ef85-6ea0-4194-a00d-52e0eefbd27c",
                    Message = "Are you sure?",
                    Details = "YES"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "b5c276e1-f492-481b-bc1d-3e86d6e553da",
                    ParentId = "6b446e00-8e80-4404-8789-3c1fde939be8",
                    Message = "Do jumping jacks first.",
                    Details = "NO"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "bf0aecad-4de9-422a-a44d-64e493360310",
                    ParentId = "6b446e00-8e80-4404-8789-3c1fde939be8",
                    Message = "Get it.",
                    Details = "YES"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "f4791936-b991-4ee5-b4a2-af64b123eaa9",
                    ParentId = "2859fe39-398e-480a-8bf7-34531e72963d",
                    Message = "Wait 'til you find a sinful, unforgettable doughnut.",
                    Details = "NO"
                },
                new ParentAssociationNodeEntity
                {
                    Id = "b85551b6-6716-43ed-b6f1-526826d5acd4",
                    ParentId = "2859fe39-398e-480a-8bf7-34531e72963d",
                    Message = "What are you waiting for? Grab it now.",
                    Details = "YES"
                });

            modelBuilder.Entity<AdventureEntity>().HasData(
                new AdventureEntity
                {
                    Id = "7e74ef05-9fc9-4163-b3df-4af2b00eaa44",
                    Name = "Doughnut decision helper",
                    StartingNodeId = "f1153d44-513f-43a9-b739-40ebb59b64e1"
                });
        }
    }
}
