namespace Data.Repository.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class DbContextWithParentCheck : DbContext
    {
        public DbContextWithParentCheck() : base()
        {
        }

        public DbContextWithParentCheck(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public override int SaveChanges()
        {
            this.RemoveOrphanChildren();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            this.RemoveOrphanChildren();
            return base.SaveChangesAsync();
        }

        private void RemoveOrphanChildren()
        {
            var modified = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var entity in modified)
            {
                ParentValidator.ValidateEntity(this, entity, ObjectContext.GetObjectType(entity.Entity.GetType()));
            }
        }
    }
}
