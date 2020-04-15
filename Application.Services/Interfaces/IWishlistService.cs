namespace Application.Services.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;
    public interface IWishlistService
    {

        string AddWishlist(string ownerID, WishlistDTO wishlist);

        string AddWishlistItem(string wishlistID, WishlistItemDTO item);

        string DeleteWishlist(string wishlistID);

        string DeleteWishlistItem(string wishlistId, string itemCode);

        string EmptyWishlist(string wishlistID);

        WishlistDTO GetWishlist(string wishlistID);

        List<WishlistItemDTO> GetWishListItems(string wishListID);

        WishlistItemDTO GetWishlistItem(string itemCode);

        List<WishlistDTO> GetWishlists(string ownerID);

        string UpdateWishlistItem(string wishlistID, WishlistItemDTO item);
    }
}
