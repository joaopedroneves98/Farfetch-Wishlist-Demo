
namespace Domain.Services.Mapping
{
    using Application.DTO;
    using Domain.Model;

    public static class WishlistItemAttributeDTOMapper
    {
        public static WishlistItemAttributeDTO ObjectToDTO(WishlistItemAttribute wishlistItemAttribute)
        {
            if (wishlistItemAttribute == null)
            {
                return null;
            }
            var response = new WishlistItemAttributeDTO
            {
                Value = wishlistItemAttribute.Value,
                Key = wishlistItemAttribute.Key,
                Id = wishlistItemAttribute.Id,
                DateCreated = wishlistItemAttribute.DateCreated,
                DateUpdated = wishlistItemAttribute.DateUpdated
            };

            return response;
        }

        public static WishlistItemAttribute DTOToObject(WishlistItemAttributeDTO wishlistItemAttributeDTO)
        {
            if (wishlistItemAttributeDTO == null)
            {
                return null;
            }
            var response = new WishlistItemAttribute
            {
                Value = wishlistItemAttributeDTO.Value,
                Key = wishlistItemAttributeDTO.Key,
                Id = wishlistItemAttributeDTO.Id,
                DateCreated = wishlistItemAttributeDTO.DateCreated,
                DateUpdated = wishlistItemAttributeDTO.DateUpdated
            };

            return response;
        }
    }
}
