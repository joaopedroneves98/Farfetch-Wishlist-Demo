namespace Presentation.WebAPI3.Controllers
{
    using Application.Services.Interfaces;
    using System.Web.Http;

    [RoutePrefix("Wishlist/v1")]
    public class WishlistItemController : ApiController
    {
        private readonly IWishlistService wishlistService;

        public WishlistItemController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        [Route("Owners/{ownerID}/Wishlists/{wishlistID}/Items")]
        [HttpGet]
        public IHttpActionResult GetWishlistItems([FromUri] string wishlistID)
        {
            var items = this.wishlistService.GetWishListItems(wishlistID);
            if (items == null)
            {
                return this.BadRequest("No items found for the provided Id");
            }
            return this.Ok(items);
        }
    }
}
