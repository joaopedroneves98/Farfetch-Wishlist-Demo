namespace Wishlist.Contracts.V1.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOwnerCreatedV1
    {
        int Id { get; }

        string Name { get; }

        string ExternalId { get; }

        DateTime DateCreated { get; }

        DateTime DateUpdated { get; }
    }
}
