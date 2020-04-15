namespace Data.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Data.Repository.Interfaces.Repositories;
    using Data.Repository.Models;
    using Domain.Model;
    using SharpRepository.EfRepository;
    using SharpRepository.Repository.Caching;

    public class WishlistRepository : EfRepository<Wishlist, Guid>, IWishlistRepository
    {
        protected WishlistContext Context { get; private set; }

        public WishlistRepository(DbContext dbContext, ICachingStrategy<Wishlist, Guid> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
            this.Context = (WishlistContext)dbContext;
        }

        public List<Wishlist> GetWishlists()
        {
            var wishlists = this.Context.Wishlists.ToList();

            return wishlists;
        }

        public Wishlist GetWishlist(string wishlistID)
        {
            var wishlist = this.Context.Wishlists.Where(w => w.ExternalId.Equals(wishlistID)).Include(w => w.WishlistItems).ToList();

            if (wishlist.Count == 0)
            {
                return null;
            }

            foreach (WishlistItem item in wishlist.ElementAt(0).WishlistItems)
            {
                item.Attributes = this.Context.WishlistItemAttributes.Where(a => a.WishlistItemId == item.Id).ToList();
            }

            return wishlist.ElementAt(0);
        }

        public string AddWishlist(Wishlist wishlist)
        {
            if (wishlist != null)
            {
                this.Context.Wishlists.Add(wishlist);
                this.Context.SaveChanges();
                return wishlist.ExternalId;
            }
            return null;
        }

        public string DeleteWishlist(string wishlistID)
        {
            var wishlist = this.GetWishlist(wishlistID);
            if (wishlist == null) { return null; }

            this.Context.Wishlists.Remove(wishlist);
            this.Context.SaveChanges();

            return wishlist.ExternalId;
        }

        public string EmptyWishlist(string wishlistID)
        {
            var wishlist = this.GetWishlist(wishlistID);

            wishlist.WishlistItems.Clear();
            return wishlist.ExternalId;
        }


        public List<WishlistItem> GetAllItems()
        {
            var items = this.Context.WishlistItems.ToList();

            return items;
        }

        public string AddWishlistItem(string wishlistID, WishlistItem item)
        {
            var wishlist = this.GetWishlist(wishlistID);
            if (wishlist != null)
            {
                item.WishlistId = wishlist.Id;

                this.Context.WishlistItems.Add(item);
                this.Context.SaveChanges();
                return item.Code;
            }
            return null;
        }

        public WishlistItem GetWishlistItem(string itemCode)
        {
            var items = this.Context.WishlistItems.Where(w => w.Code.Equals(itemCode)).Include(w => w.Attributes).ToList();

            if (items.Count == 0)
            {
                return null;
            }

            return items.ElementAt(0);
        }

        public string DeleteWishlistItem(string wishlistID, string itemCode)
        {
            var item = this.GetWishlistItem(itemCode);
            if (item == null) { return null; }

            var wishlist = this.GetWishlist(wishlistID);
            if (wishlist == null) { return null; }

            wishlist.RemoveWishlistItem(item);

            this.Context.WishlistItems.Remove(item);
            this.Context.SaveChanges();

            return item.Code;
        }

        public string UpdateWishlistItem(WishlistItem item)
        {
            if (item == null)
            {
                return null;
            }
            WishlistItem itemToUpdate = this.Context.WishlistItems
                .Where(o => o.Id == o.Id).FirstOrDefault();

            if (itemToUpdate != null)
            {
                this.Context.Entry(itemToUpdate).CurrentValues.SetValues(item);
                this.Context.SaveChanges();
                return item.Code;
            }
            return null;
        }
    }
}
