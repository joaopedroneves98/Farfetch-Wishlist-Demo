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

        string AddWishlist(Wishlist wishlist);

        string DeleteWishlist(string wishlistID);

        string EmptyWishlist(string wishlistID);

        List<WishlistItem> GetAllItems();

        string AddWishlistItem(string wishlistID, WishlistItem item);

        WishlistItem GetWishlistItem(string itemCode);

        string DeleteWishlistItem(string wishlistID, string itemCode);

        string UpdateWishlistItem(WishlistItem item);

    }
}
