namespace Presentation.WebAPI3.Controllers
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using System.Web.Http;

    [RoutePrefix("Wishlist/v1/Owners")]
    public class OwnerController : ApiController
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllOwners()
        {
            return this.Ok(this.ownerService.GetAllOwners());
        }

        [Route("{externalID}")]
        [HttpGet]
        public IHttpActionResult GetOwner([FromUri] string externalID)
        {
            var owner = this.ownerService.GetOwner(externalID);
            if (owner == null)
            {
                return this.BadRequest("No owner found for the provided Id");
            }
            return this.Ok(owner);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostOwner([FromBody]OwnerDTO owner)
        {
            if (owner == null)
            {
                return this.BadRequest("Can't add a null owner");
            }
            var added = this.ownerService.AddOwnerAsync(owner);
            if (added == null)
            {
                return this.BadRequest("Problem adding owner");
            }
            return this.Ok(added);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult PutOwner([FromBody]OwnerDTO owner)
        {
            var updatedOwner = this.ownerService.UpdateOwner(owner);
            if (updatedOwner == null)
            {
                return this.BadRequest("Owner not found");
            }
            return this.Ok(updatedOwner);
        }

        [Route("{externalID}")]
        [HttpDelete]
        public IHttpActionResult DeleteOwner([FromUri] string externalID)
        {
            var deleted = this.ownerService.DeleteOwner(externalID);
            if (deleted == null)
            {
                return this.BadRequest("Owner not found");
            }
            return this.Ok(deleted);
        }
    }
}
