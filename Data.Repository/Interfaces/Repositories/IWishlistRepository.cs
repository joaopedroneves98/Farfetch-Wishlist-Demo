namespace Data.Repository.Interfaces.Repositories
{
    using Domain.Model;
    using SharpRepository.Repository;
    using System;
    using System.Collections.Generic;

    public interface IWishlistRepository : IRepository<Wishlist, Guid>
    {
        List<Wishlist> GetWishlists();

        Wishlist GetWishlist(string wishlistID);

        Wishlist AddWishlist(Wishlist wishlist);

        Wishlist DeleteWishlist(string wishlistID);

        Wishlist EmptyWishlist(string wishlistID);

        List<WishlistItem> GetAllItems();

        WishlistItem AddWishlistItem(string wishlistID, WishlistItem item);

        WishlistItem GetWishlistItem(string itemCode);

        WishlistItem DeleteWishlistItem(string wishlistID, string itemCode);

        WishlistItem UpdateWishlistItem(WishlistItem item);

    }
}
