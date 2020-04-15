namespace Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class OwnerDTO
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public string ExternalID { get; set; }

        public string Name { get; set; }

        public List<WishlistDTO> Wishlists { get; set; }

        public OwnerDTO()
        {
            this.Wishlists = new List<WishlistDTO>();
        }
        public OwnerDTO(string externalID)
        {
            this.ExternalID = externalID;
            this.Wishlists = new List<WishlistDTO>();
        }
    }
}
