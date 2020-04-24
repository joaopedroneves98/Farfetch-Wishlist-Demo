namespace Application.Messaging.Kafka.Contracts.V1.Owner
{
    using System;
    using Application.Messaging.Kafka.Contracts.V1.Owner.Events;

    public class OwnerKafka : IOwnerKafka, IEvent
    {
        public int Id { get; set; }

        public string ExternalID { get; set; }

        public string Name { get; set; }

        public Guid EventId { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public OwnerKafka()
        {

        }

        public OwnerKafka(Guid eventId, DateTime date, int id, string name, string externalID)
        {
            this.EventId = eventId;
            this.Date = date;
            this.Id = id;
            this.Name = name;
            this.ExternalID = externalID;
        }
    }
}
