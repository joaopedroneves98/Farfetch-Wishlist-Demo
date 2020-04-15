namespace Data.Repository.Models.Mapping
{
    using Domain.Model;
    using System.Data.Entity.ModelConfiguration;

    public class WishlistMap : EntityTypeConfiguration<Wishlist>
    {
        public WishlistMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OwnerId);
            this.Property(t => t.ExternalId).HasMaxLength(200);
            this.Property(t => t.DateCreated);
            this.Property(t => t.DateUpdated);

            // Table & Column Mappings
            this.ToTable("Wishlist");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OwnerId).HasColumnName("OwnerId");
            this.Property(t => t.ExternalId).HasColumnName("ExternalId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");

            // Foreign Key
            this.HasMany(w => w.WishlistItems).WithOptional().HasForeignKey(w => w.WishlistId).WillCascadeOnDelete(true);
        }
    }
}
