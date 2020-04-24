namespace Application.Messaging.Kafka.Contracts.V1.Owner
{
    using System;
    interface IOwnerKafka
    {
        int Id { get; }

        string Name { get; }

        string ExternalID { get; }

        DateTime DateCreated { get; }

        DateTime DateUpdated { get; }
    }
}
