using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2.Interfaces
{
    public interface IOwnerClient
    {
        Task<List<OwnerDTO>> GetAllOwnersAsync();
        Task<OwnerDTO> GetOwnerAsync(string externalID);
        Task<Uri> PostOwnerAsync(OwnerDTO owner);
        Task<Uri> PutOwnerAsync(OwnerDTO owner);
        Task<Uri> DeleteOwnerAsync(string externalID);
    }
}
