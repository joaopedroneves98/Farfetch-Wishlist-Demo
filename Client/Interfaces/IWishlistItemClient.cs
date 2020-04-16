namespace Client.Interfaces
{
    using Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistItemClient
    {
        Task<WishlistItemDTO> GetItemAsync(string ownerID, string wishlistID, string itemCode);

        Task<List<WishlistItemDTO>> GetAllItemsAsync(string ownerID, string wishlistID);

        Task<Uri> PostItemAsync(string ownerID, string wishlistID, WishlistItemDTO item);

        Task<Uri> DeleteWishlistAsync(string ownerID, string wishlistID, string itemCode);
    }
}
