namespace Presentation.WebAPI3.Controllers
{
    using Application.DTO;
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

        [Route("Owners/{ownerID}/Wishlists/{wishlistID}/Items")]
        [HttpPost]
        public IHttpActionResult PostWishlistItem([FromUri]string wishlistID, [FromBody]WishlistItemDTO item)
        {
            var createdItem = this.wishlistService.AddWishlistItem(wishlistID, item);
            if (createdItem == null)
            {
                return this.BadRequest("Could not add item");
            }
            return this.Ok(createdItem);
        }

        [Route("Owners/{ownerID}/Wishlists/{wishlistID}/Items/{itemCode}")]
        [HttpGet]
        public IHttpActionResult GetWishlistItem([FromUri] string itemCode)
        {
            var wishlistItem = this.wishlistService.GetWishlistItem(itemCode);
            if (wishlistItem == null)
            {
                return this.BadRequest("No items found with a matching item code");
            }
            return this.Ok(wishlistItem);
        }

        [Route("Owners/{ownerID}/Wishlists{wishlistID}/Items/{itemCode}")]
        [HttpPut]
        public IHttpActionResult PutWishlistItem([FromUri]string wishlistID, [FromBody]WishlistItemDTO item)
        {
            var updatedItem = this.wishlistService.UpdateWishlistItem(wishlistID, item);
            if (updatedItem == null)
            {
                return this.BadRequest("Error updating the wishlist item");
            }
            return this.Ok(updatedItem);
        }

        [Route("Owners/{ownerID}/Wishlists/{wishlistID}/Items/{itemCode}")]
        [HttpDelete]
        public IHttpActionResult DeleteWishlistItem([FromUri]string wishlistID, [FromUri]string itemCode)
        {
            var deletedItem = this.wishlistService.DeleteWishlistItem(wishlistID, itemCode);
            if (deletedItem == null)
            {
                return this.NotFound();
            }
            return this.Ok(deletedItem);
        }
    }
}
