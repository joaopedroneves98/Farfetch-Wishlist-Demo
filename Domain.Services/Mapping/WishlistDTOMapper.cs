using Application.DTO;
using Domain.Model;
using System.Collections.Generic;

namespace Domain.Services.Mapping
{
    public static class WishlistDTOMapper
    {
        public static WishlistDTO ObjectToDTO(Wishlist wishlist)
        {
            if (wishlist == null)
            {
                return null;
            }

            var response = new WishlistDTO
            {
                OwnerID = wishlist.OwnerId,
                ExternalId = wishlist.ExternalId,
                Id = wishlist.Id,
                DateCreated = wishlist.DateCreated,
                DateUpdated = wishlist.DateUpdated
            };

            if (wishlist.WishlistItems.Count != 0)
            {
                foreach (WishlistItem item in wishlist.WishlistItems)
                {
                    var dto = WishlistItemDTOMapper.ObjectToDTO(item);
                    response.WishlistItems.Add(dto);
                }
            }

            return response;
        }

        public static Wishlist DTOToObject(WishlistDTO wishlistDTO)
        {
            if (wishlistDTO == null)
            {
                return null;
            }
            var response = new Wishlist
            {
                OwnerId = wishlistDTO.OwnerID,
                ExternalId = wishlistDTO.ExternalId,
                Id = wishlistDTO.Id,
                DateCreated = wishlistDTO.DateCreated,
                DateUpdated = wishlistDTO.DateUpdated,
            };

            if (wishlistDTO.WishlistItems.Count != 0)
            {
                List<WishlistItem> items = new List<WishlistItem>();

                foreach (WishlistItemDTO dto in wishlistDTO.WishlistItems)
                {
                    WishlistItem item = WishlistItemDTOMapper.DTOToObject(dto);
                    items.Add(item);
                }

                response.WishlistItems = items;
            }

            return response;
        }
    }
}
