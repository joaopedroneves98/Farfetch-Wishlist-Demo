namespace Application.Services.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;
    public interface IOwnerService
    {
        OwnerDTO AddOwner(OwnerDTO dto);

        List<OwnerDTO> GetAllOwners();

        string DeleteOwner(string ownerID);

        OwnerDTO GetOwner(string ownerID);

        string UpdateOwner(OwnerDTO dto);
    }
}
