namespace Domain.Model
{
    using System;

    public class WishlistItemAttribute : IAuditableDomainEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public int WishlistItemId { get; set; }

        public WishlistItemAttribute()
        {
        }
    }
}
