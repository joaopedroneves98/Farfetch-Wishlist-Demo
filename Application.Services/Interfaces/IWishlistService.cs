namespace Application.Services.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;
    public interface IWishlistService
    {

        WishlistDTO AddWishlist(string ownerID, WishlistDTO wishlist);

        WishlistItemDTO AddWishlistItem(string wishlistID, WishlistItemDTO item);

        WishlistDTO DeleteWishlist(string wishlistID);

        WishlistItemDTO DeleteWishlistItem(string wishlistId, string itemCode);

        WishlistDTO EmptyWishlist(string wishlistID);

        WishlistDTO GetWishlist(string wishlistID);

        List<WishlistItemDTO> GetWishListItems(string wishListID);

        WishlistItemDTO GetWishlistItem(string itemCode);

        List<WishlistDTO> GetWishlists(string ownerID);

        WishlistItemDTO UpdateWishlistItem(string wishlistID, WishlistItemDTO item);
    }
}
