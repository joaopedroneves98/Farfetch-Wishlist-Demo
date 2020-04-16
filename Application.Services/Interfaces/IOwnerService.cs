namespace Application.Services.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;
    public interface IOwnerService
    {
        OwnerDTO AddOwner(OwnerDTO dto);

        List<OwnerDTO> GetAllOwners();

        OwnerDTO DeleteOwner(string ownerID);

        OwnerDTO GetOwner(string ownerID);

        OwnerDTO UpdateOwner(OwnerDTO dto);
    }
}
