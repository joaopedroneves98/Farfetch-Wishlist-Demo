using System;

namespace Application.DTO
{
    public class WishlistItemAttributeDTO
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public int WishlistItemId { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }
        
        public WishlistItemAttributeDTO()
        {

        }

    }
}
