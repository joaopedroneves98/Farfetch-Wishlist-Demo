namespace WishList.Contracts.V1.Events
{
    using System;

    public interface IEvent
    {
        Guid EventId { get; }

        DateTime Date { get; }
    }
}