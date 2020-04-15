namespace Data.Repository.Models.Mapping
{
    using Domain.Model;
    using System.Data.Entity.ModelConfiguration;

    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name).HasMaxLength(150);
            this.Property(t => t.ExternalId).HasMaxLength(200);
            this.Property(t => t.DateCreated);
            this.Property(t => t.DateUpdated);

            // Table & Column Mappings
            this.ToTable("Owner");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ExternalId).HasColumnName("ExternalId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");

            // Foreign Key
            this.HasMany(o => o.Wishlists).WithOptional().HasForeignKey(w => w.OwnerId).WillCascadeOnDelete(true);
        }
    }
}
