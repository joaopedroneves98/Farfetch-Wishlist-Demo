namespace Client.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Client.Interfaces;

    public class OwnerClient : IOwnerClient
    {
        private readonly IOwnerService ownerService;

        public OwnerClient(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public OwnerDTO AddOwner(OwnerDTO ownerDTO)
        {
            return this.ownerService.AddOwnerAsync(ownerDTO);
        }

        public OwnerDTO DeleteOwner(string ownerId)
        {
            return this.ownerService.DeleteOwner(ownerId);
        }

        public OwnerDTO GetOwner(string ownerId)
        {
            return this.ownerService.GetOwner(ownerId);
        }

        public OwnerDTO UpdateOwner(OwnerDTO ownerDTO)
        {
            return this.ownerService.UpdateOwner(ownerDTO);
        }
    }
}
