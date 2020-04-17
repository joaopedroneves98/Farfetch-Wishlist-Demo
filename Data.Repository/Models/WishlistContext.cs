namespace Data.Repository.Models
{
    using Data.Repository.Models.Mapping;
    using Domain.Model;
    using System.Data.Entity;

    public class WishlistContext : DbContext
    {
        public WishlistContext() : base("Name=WishlistConnectionString")
        {

        }

        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<Wishlist> Wishlists { get; set; }

        public virtual DbSet<WishlistItem> WishlistItems { get; set; }

        public virtual DbSet<WishlistItemAttribute> WishlistItemAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OwnerMap());
            modelBuilder.Configurations.Add(new WishlistMap());
            modelBuilder.Configurations.Add(new WishlistItemMap());
            modelBuilder.Configurations.Add(new WishlistItemAttributeMap());
        }
    }
}
