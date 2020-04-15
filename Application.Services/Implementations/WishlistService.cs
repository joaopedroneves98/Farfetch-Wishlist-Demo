namespace Application.Services.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces.Repositories;
    using System.Collections.Generic;

    public class WishlistService : IWishlistService
    {
        private readonly IOwnerRepository ownerRepository;

        private readonly IWishlistRepository wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository,IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
            this.wishlistRepository = wishlistRepository;
        }

        public string AddWishlist(string ownerID, WishlistDTO wishlist)
        {
            throw new System.NotImplementedException();
        }

        public string AddWishlistItem(string wishlistID, WishlistItemDTO item)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteWishlist(string wishlistID)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteWishlistItem(string wishlistId, string itemCode)
        {
            throw new System.NotImplementedException();
        }

        public string EmptyWishlist(string wishlistID)
        {
            throw new System.NotImplementedException();
        }

        public WishlistDTO GetWishlist(string wishlistID)
        {
            throw new System.NotImplementedException();
        }

        public WishlistItemDTO GetWishlistItem(string itemCode)
        {
            throw new System.NotImplementedException();
        }

        public List<WishlistItemDTO> GetWishListItems(string wishListID)
        {
            throw new System.NotImplementedException();
        }

        public List<WishlistDTO> GetWishlists(string ownerID)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateWishlistItem(string wishlistID, WishlistItemDTO item)
        {
            throw new System.NotImplementedException();
        }
    }
}
