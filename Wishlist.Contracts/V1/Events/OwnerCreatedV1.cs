namespace Wishlist.Contracts.V1.Events
{
    using System;
    using WishList.Contracts.V1.Events;

    public class OwnerCreatedV1 : IOwnerCreatedV1, IEvent
    {
        public Guid EventId { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ExternalId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public OwnerCreatedV1() { }

        public OwnerCreatedV1(Guid eventId, DateTime date, int id, string name, string externalId)
        {
            this.EventId = eventId;
            this.Date = date;
            this.Id = id;
            this.Name = name;
            this.ExternalId = externalId;
        }
    }
}
