namespace Data.Repository.Interfaces.Repositories
{
    using Domain.Model;
    using SharpRepository.Repository;
    using System;
    using System.Collections.Generic;

    public interface IOwnerRepository : IRepository<Owner, Guid>
    {
        Owner GetOwnerObject(string externalID);

        Owner Add(Owner owner);

        Owner DeleteOwner(string ownerID);

        List<Owner> GetAllOwners();

        Owner UpdateOwner(Owner owner);
    }
}
