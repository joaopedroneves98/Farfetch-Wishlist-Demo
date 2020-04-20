namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Wishlist : IAuditableDomainEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public string ExternalId { get; set; }

        public int OwnerId { get; set; }

        public List<WishlistItem> WishlistItems { get; set; }

        public Wishlist()
        {
            this.WishlistItems = new List<WishlistItem>();
        }

        public void AddOrUpdateWishlistItem(WishlistItem item)
        {
            if (!this.WishlistItems.Contains(item))
            {
                item.WishlistId = this.Id;
                this.WishlistItems.Add(item);
            }
            else
            {
                this.WishlistItems.Remove(item);
                this.WishlistItems.Add(item);
            }
        }

        public void RemoveWishlistItem(WishlistItem item)
        {
            if (this.WishlistItems.Contains(item))
            {
                this.WishlistItems.Remove(item);
            }
        }
    }
}
