namespace Client.Implementations
{
    using Application.DTO;
    using Client.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class OwnerClient : HttpClient, IOwnerClient
    {
        public Task<Uri> DeleteOwnerAsync(string externalID)
        {
            throw new NotImplementedException();
        }

        public Task<List<OwnerDTO>> GetAllOwnersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OwnerDTO> GetOwnerAsync(string externalID)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PostOwnerAsync(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> PutOwnerAsync(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }
    }
}
