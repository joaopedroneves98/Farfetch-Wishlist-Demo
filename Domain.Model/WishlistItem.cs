namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class WishlistItem : IAuditableDomainEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int WishlistId { get; set; }

        public List<WishlistItemAttribute> Attributes { get; set; }

        public WishlistItem()
        {
            this.Attributes = new List<WishlistItemAttribute>();
        }
    }
}
