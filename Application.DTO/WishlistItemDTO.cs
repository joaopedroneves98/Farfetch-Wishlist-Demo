
namespace Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class WishlistItemDTO
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public int WishlistId { get; set; }

        public string Code { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public List<WishlistItemAttributeDTO> Attributes { get; set; }

        public WishlistItemDTO()
        {
            this.Attributes = new List<WishlistItemAttributeDTO>();
        }
        public WishlistItemDTO(string itemCode)
        {
            this.Code = itemCode;
            this.Attributes = new List<WishlistItemAttributeDTO>();
        }
    }
}
