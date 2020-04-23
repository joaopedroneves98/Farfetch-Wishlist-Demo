namespace Client2.Interfaces
{
    using Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IOwnerClient
    {
        Task<List<OwnerDTO>> GetAllOwnersAsync();

        Task<OwnerDTO> GetOwnerAsync(string externalID);

        Task<Uri> PostOwnerAsync(OwnerDTO owner);

        Task<Uri> PutOwnerAsync(OwnerDTO owner);

        Task<Uri> DeleteOwnerAsync(string externalID);
    }
}
