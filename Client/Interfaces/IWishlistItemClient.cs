namespace Client.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;

    public interface IWishlistItemClient
    {
        WishlistItemDTO AddWishlistItem(string wishlistID, WishlistItemDTO wishlistItemDTO);

        WishlistItemDTO DeleteWishlistItem(string wishlistId, string itemCode);

        WishlistItemDTO GetWishlistItem(string itemCode);

        List<WishlistItemDTO> GetWishlistItems(string wishListID);

        WishlistItemDTO UpdateWishlistItem(string wishlistID, WishlistItemDTO item);

    }
}
