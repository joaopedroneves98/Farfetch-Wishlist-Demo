namespace Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class WishlistDTO
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public string ExternalId { get; set; }

        public int OwnerID { get; set; }

        public List<WishlistItemDTO> WishlistItems { get; set; }

        public WishlistDTO()
        {
            this.WishlistItems = new List<WishlistItemDTO>();
        }
        public WishlistDTO(string externalID)
        {
            this.ExternalId = externalID;
            this.WishlistItems = new List<WishlistItemDTO>();
        }
    }
}
