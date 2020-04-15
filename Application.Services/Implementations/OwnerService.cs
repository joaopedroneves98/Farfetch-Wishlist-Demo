namespace Application.Services.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces.Repositories;
    using System.Collections.Generic;
    public class OwnerService : IOwnerService
    {

        private readonly IOwnerRepository ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        public OwnerDTO AddOwner(OwnerDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteOwner(string ownerID)
        {
            throw new System.NotImplementedException();
        }

        public List<OwnerDTO> GetAllOwners()
        {
            throw new System.NotImplementedException();
        }

        public OwnerDTO GetOwner(string ownerID)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateOwner(OwnerDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
