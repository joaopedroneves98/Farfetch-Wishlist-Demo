namespace Client.Interfaces
{
    using Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOwnerClient
    {

        OwnerDTO AddOwner(OwnerDTO ownerDTO);

        OwnerDTO DeleteOwner(string ownerId);

        OwnerDTO GetOwner(string ownerId);

        OwnerDTO UpdateOwner(OwnerDTO ownerDTO);
    }
}
