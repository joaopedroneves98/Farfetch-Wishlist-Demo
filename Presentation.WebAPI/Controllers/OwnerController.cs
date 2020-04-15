namespace Presentation.WebAPI.Controllers
{
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
    }
}
