namespace Application.Messaging.Kafka.Contracts.V1.Owner.Events
{
    using System;

    public interface IEvent
    {
        Guid EventId { get; }

        DateTime Date { get; }
    }
}
