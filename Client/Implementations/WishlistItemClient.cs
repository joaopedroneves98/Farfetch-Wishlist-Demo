using Application.DTO;
using Application.Services.Interfaces;
using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Implementations
{
    public class WishlistItemClient : IWishlistItemClient
    {
        private readonly IWishlistService wishlistService;

        public WishlistItemClient(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        public WishlistItemDTO AddWishlistItem(string wishlistID, WishlistItemDTO wishlistItemDTO)
        {
            return this.wishlistService.AddWishlistItem(wishlistID, wishlistItemDTO);
        }

        public WishlistItemDTO DeleteWishlistItem(string wishlistId, string itemCode)
        {
            return this.wishlistService.DeleteWishlistItem(wishlistId, itemCode);
        }

        public WishlistItemDTO GetWishlistItem(string itemCode)
        {
            return this.wishlistService.GetWishlistItem(itemCode);
        }

        public List<WishlistItemDTO> GetWishlistItems(string wishListID)
        {
            return this.wishlistService.GetWishListItems(wishListID);
        }

        public WishlistItemDTO UpdateWishlistItem(string wishlistID, WishlistItemDTO item)
        {
            return this.wishlistService.UpdateWishlistItem(wishlistID, item);
        }
    }
}
