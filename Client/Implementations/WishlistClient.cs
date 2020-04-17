namespace Client.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Client.Interfaces;
    using System.Collections.Generic;

    public class WishlistClient : IWishlistClient
    {
        private readonly IWishlistService wishlistService;

        public WishlistClient(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        public WishlistDTO AddWishlist(string ownerId, WishlistDTO wishlistDTO)
        {
            return this.wishlistService.AddWishlist(ownerId, wishlistDTO);
        }

        public WishlistDTO DeleteWishlist(string wishlistId)
        {
            return this.wishlistService.DeleteWishlist(wishlistId);
        }

        public WishlistDTO GetWishlist(string wishlistId)
        {
            return this.wishlistService.GetWishlist(wishlistId);
        }

        public List<WishlistDTO> GetWishlists(string ownerId)
        {
            return this.wishlistService.GetWishlists(ownerId);
        }
    }
}
