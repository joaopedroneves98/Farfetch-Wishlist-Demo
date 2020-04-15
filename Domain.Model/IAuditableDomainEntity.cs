namespace Domain.Model
{
    using System;

    public interface IAuditableDomainEntity : IDomainEntity
    {
        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
