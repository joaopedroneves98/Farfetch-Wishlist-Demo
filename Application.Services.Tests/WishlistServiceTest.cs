using System;
using System.Collections.Generic;
using Application.Services.Implementations;
using Data.Repository.Interfaces.Repositories;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Services.Tests
{
    [TestClass]
    public class WishlistServiceTest
    {
        private Mock<IWishlistRepository> mockWishlistRepository;

        private Mock<IOwnerRepository> mockOwnerRepository;

        private WishlistService wishlistService;

        [TestInitialize]
        public void Initializer()
        {
            this.mockWishlistRepository = new Mock<IWishlistRepository>();
            this.mockOwnerRepository = new Mock<IOwnerRepository>();
            this.wishlistService = new WishlistService(this.mockWishlistRepository.Object, this.mockOwnerRepository.Object);
        }

        [TestMethod]
        public void WishlistService_GetWishlists_ReturnsList()
        {
            var owner = new Owner
            {
                Id = 1,
                ExternalId = "Teste1"
            };

            var wishlist = new Wishlist
            {
                OwnerId = 1
            };

            var expected = new List<Wishlist>();
            expected.Add(wishlist);

            this.mockOwnerRepository.Setup(m => m.GetOwnerObject(owner.ExternalId)).Returns(owner);
            this.mockWishlistRepository.Setup(w => w.GetWishlists()).Returns(expected);

            var result = this.wishlistService.GetWishlists(owner.ExternalId);

            Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void WishlistService_GetWishlists_NoListForOwnerReturnsNothing()
        {
            var owner = new Owner
            {
                Id = 1,
                ExternalId = "Teste1"
            };

            var wishlist = new Wishlist();

            var expected = new List<Wishlist>();
            expected.Add(wishlist);

            this.mockOwnerRepository.Setup(m => m.GetOwnerObject(owner.ExternalId)).Returns(owner);
            this.mockWishlistRepository.Setup(w => w.GetWishlists()).Returns(expected);

            var result = this.wishlistService.GetWishlists(owner.ExternalId);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WishlistService_GetWishlist_ReturnsDTO()
        {
            var wishlist = new Wishlist { 
                ExternalId = "Wishlist1"
            };
            this.mockWishlistRepository.Setup(w => w.GetWishlist(wishlist.ExternalId)).Returns(wishlist);

            var result = this.wishlistService.GetWishlist(wishlist.ExternalId);

            Assert.AreEqual(wishlist.ExternalId, result.ExternalId);
        }

        [TestMethod]
        public void WishlistService_GetWishlist_ResultIsNull()
        {
            Wishlist wishlist = null;
            this.mockWishlistRepository.Setup(w => w.GetWishlist("")).Returns(wishlist);

            var result = this.wishlistService.GetWishlist("");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_EmptyWishlist_ReturnsDTO()
        {
            var wishlist = new Wishlist
            {
                ExternalId = "Wishlist1"
            };

            this.mockWishlistRepository.Setup(w => w.EmptyWishlist(wishlist.ExternalId)).Returns(wishlist);

            var result = this.wishlistService.EmptyWishlist(wishlist.ExternalId);

            Assert.AreEqual(wishlist.ExternalId, result.ExternalId);
        }
    }
}
