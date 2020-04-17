namespace Client.Interfaces
{
    using Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistClient
    {
        WishlistDTO AddWishlist(string ownerId, WishlistDTO wishlistDTO);

        WishlistDTO DeleteWishlist(string wishlistId);

        WishlistDTO GetWishlist(string wishlistId);

        List<WishlistDTO> GetWishlists(string ownerId);

    }
}
