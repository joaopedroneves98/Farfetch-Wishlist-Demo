namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Owner : IAuditableDomainEntity
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }

        public List<Wishlist> Wishlists { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public Owner()
        {
            this.Wishlists = new List<Wishlist>();
        }
    }
}
