
namespace Domain.Services.Mapping
{
    using Application.DTO;
    using Domain.Model;
    using System.Collections.Generic;

    public static class WishlistItemDTOMapper
    {
        public static WishlistItemDTO ObjectToDTO(WishlistItem item)
        {
            if (item == null)
            {
                return null;
            }
            var response = new WishlistItemDTO
            {
                Name = item.Name,
                Price = item.Price,
                Code = item.Code,
                Id = item.Id,
                WishlistId = item.WishlistId,
                DateCreated = item.DateCreated,
                DateUpdated = item.DateUpdated
            };

            if (item.Attributes.Count != 0)
            {
                List<WishlistItemAttributeDTO> attributeListDTO = new List<WishlistItemAttributeDTO>();

                foreach (WishlistItemAttribute attribute in item.Attributes)
                {
                    WishlistItemAttributeDTO attributeDTO = WishlistItemAttributeDTOMapper.ObjectToDTO(attribute);
                    attributeListDTO.Add(attributeDTO);
                }

                response.Attributes = attributeListDTO;
            }

            return response;
        }

        public static WishlistItem DTOToObject(WishlistItemDTO itemDTO)
        {
            if (itemDTO == null)
            {
                return null;
            }
            var response = new WishlistItem
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                Code = itemDTO.Code,
                Id = itemDTO.Id,
                WishlistId = itemDTO.WishlistId,
                DateCreated = itemDTO.DateCreated,
                DateUpdated = itemDTO.DateUpdated
            };

            if (itemDTO.Attributes.Count != 0)
            {
                List<WishlistItemAttribute> attributeList = new List<WishlistItemAttribute>();

                foreach (WishlistItemAttributeDTO attributeDTO in itemDTO.Attributes)
                {
                    WishlistItemAttribute attribute = WishlistItemAttributeDTOMapper.DTOToObject(attributeDTO);
                    attributeList.Add(attribute);
                }

                response.Attributes = attributeList;
            }

            return response;
        }
    }
}
