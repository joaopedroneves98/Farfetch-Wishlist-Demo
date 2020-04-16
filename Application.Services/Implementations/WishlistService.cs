namespace Application.Services.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces.Repositories;
    using Domain.Services.Mapping;
    using System.Collections.Generic;

    public class WishlistService : IWishlistService
    {
        private readonly IOwnerRepository ownerRepository;

        private readonly IWishlistRepository wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository, IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
            this.wishlistRepository = wishlistRepository;
        }

        public WishlistDTO AddWishlist(string ownerID, WishlistDTO wishlist)
        {
            var owner = this.ownerRepository.GetOwnerObject(ownerID);
            if (owner == null || wishlist == null)
            {
                return null;
            }
            wishlist.OwnerID = owner.Id;
            var wishlistObject = WishlistDTOMapper.DTOToObject(wishlist);
            var added = this.wishlistRepository.AddWishlist(wishlistObject);

            if (added == null)
            {
                return null;
            }
            return WishlistDTOMapper.ObjectToDTO(added);
        }

        public WishlistItemDTO AddWishlistItem(string wishlistID, WishlistItemDTO item)
        {
            if (item == null || wishlistID == null)
            {
                return null;
            }
            var itemObject = WishlistItemDTOMapper.DTOToObject(item);
            var addedItem = this.wishlistRepository.AddWishlistItem(wishlistID, itemObject);
            if (addedItem == null)
            {
                return null;
            }
            return WishlistItemDTOMapper.ObjectToDTO(addedItem);
        }

        public WishlistDTO DeleteWishlist(string wishlistID)
        {
            if (wishlistID == null)
            {
                return null;
            }
            var deletedWishlist = this.wishlistRepository.DeleteWishlist(wishlistID);
            if (deletedWishlist == null)
            {
                return null;
            }
            return WishlistDTOMapper.ObjectToDTO(deletedWishlist);
        }

        public WishlistItemDTO DeleteWishlistItem(string wishlistId, string itemCode)
        {
            if (wishlistId == null || itemCode == null)
            {
                return null;
            }
            var deletedItem = this.wishlistRepository.DeleteWishlistItem(wishlistId, itemCode);
            if (deletedItem == null)
            {
                return null;
            }
            return WishlistItemDTOMapper.ObjectToDTO(deletedItem);
        }

        public WishlistDTO EmptyWishlist(string wishlistID)
        {
            if (wishlistID == null)
            {
                return null;
            }
            var emptyList = this.wishlistRepository.EmptyWishlist(wishlistID);
            if (emptyList == null)
            {
                return null;
            }
            return WishlistDTOMapper.ObjectToDTO(emptyList);
        }

        public WishlistDTO GetWishlist(string wishlistID)
        {
            var wishlist = this.wishlistRepository.GetWishlist(wishlistID);
            if (wishlist == null)
            {
                return null;
            }
            return WishlistDTOMapper.ObjectToDTO(wishlist);
        }

        public WishlistItemDTO GetWishlistItem(string itemCode)
        {
            var wishlistItem = this.wishlistRepository.GetWishlistItem(itemCode);
            if (wishlistItem == null)
            {
                return null;
            }
            return WishlistItemDTOMapper.ObjectToDTO(wishlistItem);
        }

        public List<WishlistItemDTO> GetWishListItems(string wishListID)
        {
            var items = this.wishlistRepository.GetAllItems();
            var wishlist = this.wishlistRepository.GetWishlist(wishListID);
            if (wishlist == null)
            {
                return null;
            }
            var result = new List<WishlistItemDTO>();
            foreach (var i in items)
            {
                if (i.WishlistId.Equals(wishlist.Id))
                {
                    result.Add(WishlistItemDTOMapper.ObjectToDTO(i));
                }
            }
            return result;
        }

        public List<WishlistDTO> GetWishlists(string ownerID)
        {
            var wishlists = this.wishlistRepository.GetWishlists();
            var owner = this.ownerRepository.GetOwnerObject(ownerID);
            if (owner == null || wishlists == null)
            {
                return null;
            }
            List<WishlistDTO> wishlistsDTO = new List<WishlistDTO>();
            foreach (var w in wishlists)
            {
                if (w.OwnerId.Equals(owner.Id))
                {
                    wishlistsDTO.Add(WishlistDTOMapper.ObjectToDTO(w));
                }
            }
            return wishlistsDTO;
        }

        public WishlistItemDTO UpdateWishlistItem(string wishlistID, WishlistItemDTO item)
        {
            if (wishlistID == null || item == null)
            {
                return null;
            }
            var updatedItem = this.wishlistRepository.UpdateWishlistItem(WishlistItemDTOMapper.DTOToObject(item));
            if (updatedItem == null)
            {
                return null;
            }
            return WishlistItemDTOMapper.ObjectToDTO(updatedItem);
        }
    }
}
