using SC.Service.Data.Model.Contracts;
using SC.Service.Data.Model.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SC.Service.Data.Model
{
    public sealed class EFContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<AnnouncementEntity> Announcements { get; set; }

        public EFContext()
            : base("SC.Service")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string SingularEntityText = "Entity";

            EnglishPluralizationService pluralizer = new EnglishPluralizationService();

            modelBuilder.Types().Where(type => type.Name.EndsWith(SingularEntityText)).Configure(c =>
            {
                string clrTypeName = c.ClrType.Name;
                string entityName = clrTypeName.Substring(0, clrTypeName.Length - SingularEntityText.Length);
                c.ToTable(pluralizer.Pluralize(entityName));
            });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            BindTrackableProperties();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            BindTrackableProperties();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void BindTrackableProperties()
        {
            var identity = Thread.CurrentPrincipal.Identity;

            foreach (DbEntityEntry entry in base.ChangeTracker.Entries().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                if (entry.State == EntityState.Added && entry.Entity is ICreationTrackable)
                {
                    ((ICreationTrackable)entry.Entity).CreatedOn = DateTime.UtcNow;

                    if (identity != null && identity.IsAuthenticated)
                    {
                        ((ICreationTrackable)entry.Entity).CreatedBy = identity.Name;
                    }
                }

                if (entry.Entity is IUpdateTrackable)
                {
                    ((IUpdateTrackable)entry.Entity).UpdatedOn = DateTime.UtcNow;

                    if (identity != null && identity.IsAuthenticated)
                    {
                        ((IUpdateTrackable)entry.Entity).UpdatedBy = identity.Name;
                    }
                }
            }
        }
    }
}
