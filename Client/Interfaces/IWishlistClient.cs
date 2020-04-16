namespace Client.Interfaces
{
    using Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistClient
    {
        Task<WishlistDTO> GetWishlistAsync(string ownerID, string externalID);

        Task<List<WishlistDTO>> GetAllWishlistsAsync(string ownerID);

        Task<Uri> PostWishlistAsync(string ownerID, WishlistDTO wishlist);

        Task<Uri> DeleteWishlistAsync(string ownerID, string externalID);
    }
}
