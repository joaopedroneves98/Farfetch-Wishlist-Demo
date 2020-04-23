using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Wishlist Client");
                Console.WriteLine("1) Add Owner");
                Console.WriteLine("2) Get Owner");
                Console.WriteLine("3) Get all Owners");
                Console.WriteLine("4) Add Wishlist");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":

                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        static void CreateOwner()
        {
            Console.WriteLine("Name of the owner: ");
            string name = Console.ReadLine();

            Console.WriteLine("External ID of the Owner:");
            string externalId = Console.ReadLine();

            try
            {
                var owner = new OwnerDTO
                {
                    Name = name,
                    ExternalID = externalId,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                
            }
        }
    }
}
