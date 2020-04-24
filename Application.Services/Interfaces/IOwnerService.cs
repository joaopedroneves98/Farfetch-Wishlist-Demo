namespace Application.Services.Interfaces
{
    using Application.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOwnerService
    {
        Task<OwnerDTO> AddOwnerAsync(OwnerDTO dto);

        List<OwnerDTO> GetAllOwners();

        OwnerDTO DeleteOwner(string ownerID);

        OwnerDTO GetOwner(string ownerID);

        OwnerDTO UpdateOwner(OwnerDTO dto);
    }
}
