namespace Client2.Implementations
{
    using Application.DTO;
    using Client2.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class WishlistItemClient : HttpClient, IWishlistItemClient
    {

        public WishlistItemClient(string address)
        {
            this.BaseAddress = new Uri(address);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Uri> DeleteWishlistAsync(string ownerID, string wishlistID, string itemCode)
        {
            var response = await this.DeleteAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{wishlistID}/Items/{itemCode}");
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<List<WishlistItemDTO>> GetAllItemsAsync(string ownerID, string wishlistID)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{wishlistID}/Items/");
            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadAsAsync<List<WishlistItemDTO>>();
                return items;
            }
            throw new Exception($"Error: No items found for wishlist {wishlistID}");
        }

        public async Task<WishlistItemDTO> GetItemAsync(string ownerID, string wishlistID, string itemCode)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{wishlistID}/Items/{itemCode}");
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsAsync<WishlistItemDTO>();
                return item;
            }
            throw new Exception($"Error: No Item found for code {itemCode}");
        }

        public async Task<Uri> PostItemAsync(string ownerID, string wishlistID, WishlistItemDTO item)
        {
            var response = await this.PostAsJsonAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{wishlistID}/Items", item);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
