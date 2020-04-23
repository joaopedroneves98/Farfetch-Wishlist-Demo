namespace Client2.Implementations
{
    using Application.DTO;
    using Client2.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class OwnerClient : HttpClient, IOwnerClient
    {
        public OwnerClient(string address)
        {
            this.BaseAddress = new Uri(address);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Uri> DeleteOwnerAsync(string externalID)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{externalID}");
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<List<OwnerDTO>> GetAllOwnersAsync()
        {
            var owners = new List<OwnerDTO>();
            var response = await this.GetAsync("Wishlist/v1/Owners");
            if (response.IsSuccessStatusCode)
            {
                owners = await response.Content.ReadAsAsync<List<OwnerDTO>>();
                return owners;
            }
            throw new Exception("Error: No Owners found");
        }

        public async Task<OwnerDTO> GetOwnerAsync(string externalID)
        {
            var response = await this.GetAsync($"/Wishlist/v1/Owners/{externalID}");
            if (response.IsSuccessStatusCode)
            {
                OwnerDTO owner = await response.Content.ReadAsAsync<OwnerDTO>();
                return owner;
            }

            throw new Exception("Error: No Owner found with external Id " + externalID);
        }

        public async Task<Uri> PostOwnerAsync(OwnerDTO owner)
        {
            var response = await this.PostAsJsonAsync("/Wishlist/v1/Owners/", owner);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<Uri> PutOwnerAsync(OwnerDTO owner)
        {
            var response = await this.PutAsJsonAsync("/Wishlist/v1/Owners/", owner);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
