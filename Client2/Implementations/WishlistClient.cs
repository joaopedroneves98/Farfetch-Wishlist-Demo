using Application.DTO;
using Client2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client2.Implementations
{
    public class WishlistClient : HttpClient, IWishlistClient
    {

        public WishlistClient(string address)
        {
            this.BaseAddress = new Uri(address);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Uri> DeleteWishlistAsync(string ownerID, string externalID)
        {
            var response = await this.DeleteAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{externalID}");
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<List<WishlistDTO>> GetAllWishlistsAsync(string ownerID)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/");
            if (response.IsSuccessStatusCode)
            {
                var wishlists = await response.Content.ReadAsAsync<List<WishlistDTO>>();
                return wishlists;
            }
            throw new Exception("Error: No wishlists found");
        }

        public async Task<WishlistDTO> GetWishlistAsync(string ownerID, string externalID)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/{externalID}");
            if (response.IsSuccessStatusCode)
            {
                var wishlist = await response.Content.ReadAsAsync<WishlistDTO>();
                return wishlist;
            }
            throw new Exception($"Error: Wishlist not found with the id {externalID}");
        }

        public async Task<Uri> PostWishlistAsync(string ownerID, WishlistDTO wishlist)
        {
            var response = await this.PostAsJsonAsync($"/Wishlist/v1/Owners/{ownerID}/Wishlists/", wishlist);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
