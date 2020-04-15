namespace Domain.Services.Mapping
{
    using Application.DTO;
    using Domain.Model;
    using System.Collections.Generic;
    public static class OwnerDTOMapper
    {
        public static OwnerDTO ObjectToDTO(Owner owner)
        {
            if (owner == null)
            {
                return null;
            }

            var response = new OwnerDTO
            {
                Name = owner.Name,
                ExternalID = owner.ExternalId,
                Id = owner.Id,
                DateCreated = owner.DateCreated,
                DateUpdated = owner.DateUpdated
            };

            if (owner.Wishlists.Count != 0)
            {
                List<WishlistDTO> wishlists = new List<WishlistDTO>();
                foreach (var w in owner.Wishlists)
                {
                    WishlistDTO wishlistDTO = WishlistDTOMapper.ObjectToDTO(w);
                    wishlists.Add(wishlistDTO);
                }
                response.Wishlists = wishlists;
            }
            return response;
        }

        public static Owner DTOToObject(OwnerDTO ownerDTO)
        {
            if (ownerDTO == null)
            {
                return null;
            }

            var response = new Owner
            {
                Name = ownerDTO.Name,
                ExternalId = ownerDTO.ExternalID,
                Id = ownerDTO.Id,
                DateCreated = ownerDTO.DateCreated,
                DateUpdated = ownerDTO.DateUpdated
            };

            if (ownerDTO.Wishlists.Count != 0)
            {
                List<Wishlist> wishlists = new List<Wishlist>();

                foreach (WishlistDTO dto in ownerDTO.Wishlists)
                {
                    Wishlist wishlist = WishlistDTOMapper.DTOToObject(dto);

                    wishlists.Add(wishlist);
                }

                response.Wishlists = wishlists;
            }

            return response;
        }
    }
}
