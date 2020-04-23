namespace Client2
{
    using Application.DTO;
    using Client2.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Program
    {
        private static readonly OwnerClient ownerClient = new OwnerClient("https://localhost:44336/");

        private static readonly WishlistClient wishlistClient = new WishlistClient("https://localhost:44336/");

        static async Task Main()
        {
            do
            {
                Console.WriteLine("---- Wishlist Client ----");
                Console.WriteLine("1) Add Owner");
                Console.WriteLine("2) Get Owner");
                Console.WriteLine("3) Get all Owners");
                Console.WriteLine("4) Delete Owner");
                Console.WriteLine("5) Add Wishlist");
                Console.WriteLine("6) Get Wishlist");
                Console.WriteLine("7) Get all Wishlists");
                Console.WriteLine("8) Delete Wishlist");
                Console.WriteLine("0 -> Exit");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        await PerformClientCallAndWaitForInput(CreateOwner);
                        break;

                    case "2":
                        await PerformClientCallAndWaitForInput(GetOwner);
                        break;

                    case "3":
                        await PerformClientCallAndWaitForInput(GetAllOwners);
                        break;

                    case "4":
                        await PerformClientCallAndWaitForInput(DeleteOwner);
                        break;

                    case "5":
                        await PerformClientCallAndWaitForInput(CreateWishlist);
                        break;

                    case "6":
                        await PerformClientCallAndWaitForInput(GetWishlist);
                        break;

                    case "7":
                        await PerformClientCallAndWaitForInput(GetWishlists);
                        break;

                    case "8":
                        await PerformClientCallAndWaitForInput(DeleteWishlist);
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        static Task PerformClientCallAndWaitForInput(Func<Task> performCall)
        {
            return performCall()
                .ContinueWith(async callTask =>
                {
                    await callTask;
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                );
        }

        static async Task CreateOwner()
        {
            Console.WriteLine("Please write the name of the Owner:");
            var name = Console.ReadLine();

            Console.WriteLine("Please write the External ID of the Owner:");
            var externalID = Console.ReadLine();
            try
            {
                var owner = new OwnerDTO(externalID)
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                var url = await ownerClient.PostOwnerAsync(owner);
                Console.WriteLine($"Created the owner {externalID}. {url}");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task GetOwner()
        {
            Console.WriteLine("Please write the External ID of the Owner:");
            var externalID = Console.ReadLine();
            try
            {
                var owner = await ownerClient.GetOwnerAsync(externalID);
                Console.WriteLine($"---------------------\n" +
                    $"Name: {owner.Name}\n" +
                    $"ExternalID: {owner.ExternalID} \n" +
                    $"Date Created: {owner.DateCreated}\n" +
                    $"Date Updated: {owner.DateUpdated}\n" +
                    $"ID: {owner.Id}\n" +
                    $"---------------------\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task GetAllOwners()
        {
            try
            {
                var list = await ownerClient.GetAllOwnersAsync();
                ShowAllOwners(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ShowAllOwners(List<OwnerDTO> list)
        {
            foreach (var dto in list)
            {
                Console.WriteLine($"-------------------\n" +
                    $"Id: {dto.Id}" +
                    $"\nExternalId: {dto.ExternalID}" +
                    $"\nName: {dto.Name}" +
                    $"\nDate Created: {dto.DateCreated}" +
                    $"\nDate Updated: {dto.DateUpdated} \n" +
                    $"-------------------\n");
            }
        }

        static async Task DeleteOwner()
        {
            Console.WriteLine("Please write the External Id of the Owner:");
            var externalID = Console.ReadLine();
            try
            {
                var url = await ownerClient.DeleteOwnerAsync(externalID);
                Console.WriteLine($"Deleted the owner: {externalID}. {url}");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task CreateWishlist()
        {
            Console.WriteLine("Please write the external ID of the Owner you want to add the Wishlist to:");
            var ownerExternalID = Console.ReadLine();

            Console.WriteLine("Please write the External ID of the Wishlist:");
            var externalID = Console.ReadLine();
            try
            {
                var wishlistToAdd = new WishlistDTO
                {
                    ExternalId = externalID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                var url = await wishlistClient.PostWishlistAsync(ownerExternalID, wishlistToAdd);
                Console.WriteLine($"Created the wishlist {externalID}. {url}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task GetWishlists()
        {
            Console.WriteLine("Please write the external Id of the Owner you want to get the Wishlists from:");
            var ownerExternalID = Console.ReadLine();
            try
            {
                var list = await wishlistClient.GetAllWishlistsAsync(ownerExternalID);
                ShowAllWishlists(ownerExternalID, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ShowAllWishlists(string ownerExternalID, List<WishlistDTO> list)
        {
            Console.WriteLine($"-------------------\n" +
                   $"Wishlists from owner {ownerExternalID}\n");

            if (list.Count > 0)
            {
                foreach (var wishlist in list)
                {
                    Console.WriteLine(
                        $"-------------------\n" +
                        $"Id: {wishlist.Id}" +
                        $"\nExternal ID: {wishlist.ExternalId}" +
                        $"\nOwner ID: {wishlist.OwnerID}" +
                        $"\nDate Created: {wishlist.DateCreated}" +
                        $"\nDate Updated: {wishlist.DateUpdated} \n" +
                        $"-------------------\n");
                }
            }
            else Console.WriteLine($"The list is empty");
        }

        static async Task GetWishlist()
        {
            Console.WriteLine("Please write the External Id of the Owner:");
            var ownerExternalID = Console.ReadLine();

            Console.WriteLine("Please write the External Id of the Wishlist:");
            var wishlistExternalID = Console.ReadLine();

            try
            {
                var wishlist = await wishlistClient.GetWishlistAsync(ownerExternalID, wishlistExternalID);
                Console.WriteLine($"---------------------\n" +
                        $"Id: {wishlist.Id}" +
                        $"\nExternal ID: {wishlist.ExternalId}" +
                        $"\nOwner ID: {wishlist.OwnerID}" +
                        $"\nDate Created: {wishlist.DateCreated}" +
                        $"\nDate Updated: {wishlist.DateUpdated} \n" +
                        $"-------------------\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task DeleteWishlist()
        {
            Console.WriteLine("Please write the External Id of the Owner you want to delete the List from:");
            var ownerExternalID = Console.ReadLine();

            Console.WriteLine("Please write the External Id of the Wishlist you want to delete:");
            var wishlistExternalID = Console.ReadLine();
            try
            {
                var url = await wishlistClient.DeleteWishlistAsync(ownerExternalID, wishlistExternalID);
                Console.WriteLine($"Deleted the wishlist {wishlistExternalID}. {url}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
