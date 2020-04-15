namespace Data.Repository.Models.Mapping
{
    using Domain.Model;
    using System.Data.Entity.ModelConfiguration;

    public class WishlistItemMap : EntityTypeConfiguration<WishlistItem>
    {
        public WishlistItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(150);

            this.Property(t => t.Price);
            this.Property(t => t.WishlistId);
            this.Property(t => t.DateCreated);
            this.Property(t => t.DateUpdated);
            this.Property(t => t.Code);

            // Table & Column Mappings
            this.ToTable("WishlistItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.WishlistId).HasColumnName("WishlistId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
            this.Property(t => t.Price).HasColumnName("Price");

            // Foreign Key
            this.HasMany(i => i.Attributes).WithOptional().HasForeignKey(a => a.WishlistItemId).WillCascadeOnDelete(true);
        }
    }
}
