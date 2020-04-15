namespace Data.Repository.Models.Mapping
{
    using Domain.Model;
    using System.Data.Entity.ModelConfiguration;

    public class WishlistItemAttributeMap : EntityTypeConfiguration<WishlistItemAttribute>
    {
        public WishlistItemAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DateCreated);
            this.Property(t => t.DateUpdated);
            this.Property(t => t.WishlistItemId);
            this.Property(t => t.Value);
            this.Property(t => t.Key);

            // Table & Column Mappings
            this.ToTable("WishlistItemAttribute");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WishlistItemId).HasColumnName("WishlistItemId");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
        }
    }
}
