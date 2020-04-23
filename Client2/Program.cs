using Application.DTO;
using Client2.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    public class Program
    {
        private static readonly OwnerClient ownerClient = new OwnerClient("https://localhost:44336/");

        static async Task Main()
        {
            do
            {
                Console.WriteLine("---- Wishlist Client ----");
                Console.WriteLine("1) Add Owner");
                Console.WriteLine("2) Get Owner");
                Console.WriteLine("3) Get all Owners");
                Console.WriteLine("4) Delete Owner");
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
    }
}
