namespace Presentation.WebAPI3.Controllers
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using System.Web.Http;

    [RoutePrefix("Wishlist/v1")]
    public class WishlistController : ApiController
    {
        private readonly IWishlistService wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        [Route("Owners/{ownerID}/Wishlists")]
        [HttpGet]
        public IHttpActionResult GetWishlists([FromUri] string ownerID)
        {
            var wishlists = this.wishlistService.GetWishlists(ownerID);
            if (wishlists == null)
            {
                return this.BadRequest("No wishlists found for the provided owner ID");
            }
            return this.Ok(wishlists);
        }

        [Route("Owners/{ownerID}/Wishlists")]
        [HttpPost]
        public IHttpActionResult PostWishlist([FromUri]string ownerID, [FromBody] WishlistDTO wishlist)
        {
            var createdWishlist = this.wishlistService.AddWishlist(ownerID, wishlist);

            if (createdWishlist == null)
            {
                return this.BadRequest("Problem adding list");
            }
            return this.Ok(createdWishlist);
        }

        [Route("Owners/{ownerID}/Wishlists/{externalID}")]
        [HttpGet]
        public IHttpActionResult GetWishlist([FromUri] string externalID)
        {
            var wishlist = this.wishlistService.GetWishlist(externalID);
            if (wishlist == null)
            {
                return this.BadRequest("No wishlist with the provided Id was found");
            }
            return Ok(wishlist);
        }

        [Route("Owners/{ownerID}/Wishlists/{externalID}")]
        [HttpDelete]
        public IHttpActionResult DeleteWishlist([FromUri] string externalID)
        {
            var deletedWishlist = this.wishlistService.DeleteWishlist(externalID);

            if (deletedWishlist == null)
            {
                return this.BadRequest("No wishlist with the provided Id was found");
            }
            return this.Ok(deletedWishlist);
        }
    }
}
