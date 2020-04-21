using System;
using System.Collections.Generic;
using Application.Services.Implementations;
using Data.Repository.Interfaces.Repositories;
using Domain.Model;
using Domain.Services.Mapping;
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
            var wishlist = new Wishlist
            {
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

        [TestMethod]
        public void WishlistService_DeleteWishlist_ReturnsDTO()
        {
            var wishlist = new Wishlist
            {
                ExternalId = "Wishlist1"
            };

            this.mockWishlistRepository.Setup(w => w.DeleteWishlist(wishlist.ExternalId)).Returns(wishlist);

            var result = this.wishlistService.DeleteWishlist(wishlist.ExternalId);

            Assert.AreEqual("Wishlist1", result.ExternalId);
        }

        [TestMethod]
        public void WishlistService_DeleteWishlist_ReturnsNull()
        {
            Wishlist nullWish = null;

            this.mockWishlistRepository.Setup(w => w.DeleteWishlist("")).Returns(nullWish);

            var result = this.wishlistService.DeleteWishlist("");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_GetWishlistItem_ReturnsDTO()
        {
            var item = new WishlistItem
            {
                Name = "TestItem",
                Code = "TestItem1"
            };

            this.mockWishlistRepository.Setup(w => w.GetWishlistItem(item.Code)).Returns(item);

            var result = this.wishlistService.GetWishlistItem(item.Code);

            Assert.AreEqual("TestItem1", result.Code);
        }

        [TestMethod]
        public void WishlistService_GetWishlistItems_ReturnsList()
        {
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            var items = new List<WishlistItem>
            {
                new WishlistItem
                {
                    Code = "item1",
                    Name = "Item1",
                    WishlistId = 1
                }
            };

            this.mockWishlistRepository.Setup(w => w.GetAllItems()).Returns(items);
            this.mockWishlistRepository.Setup(w => w.GetWishlist(wishlist.ExternalId)).Returns(wishlist);

            var result = this.wishlistService.GetWishListItems(wishlist.ExternalId);

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void WishlistService_DeleteWishlistItem_ReturnsDTO()
        {
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            var item = new WishlistItem
            {
                Code = "ItemCode1",
                WishlistId = wishlist.Id
            };

            this.mockWishlistRepository.Setup(w => w.DeleteWishlistItem(wishlist.ExternalId, item.Code)).Returns(item);

            var result = this.wishlistService.DeleteWishlistItem(wishlist.ExternalId, item.Code);

            Assert.AreEqual("ItemCode1", result.Code);
        }

        [TestMethod]
        public void WishlistService_AddWishlist_ReturnsDTO()
        {
            var owner = new Owner
            {
                Name = "Test",
                ExternalId = "Test1",
                Id = 1
            };
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };

            this.mockOwnerRepository.Setup(o => o.GetOwnerObject(owner.ExternalId)).Returns(owner);
            this.mockWishlistRepository.Setup(w => w.AddWishlist(It.IsAny<Wishlist>())).Returns(wishlist);

            var result = this.wishlistService.AddWishlist(owner.ExternalId, WishlistDTOMapper.ObjectToDTO(wishlist));

            Assert.AreEqual("list", result.ExternalId);
        }

        [TestMethod]
        public void WishlistService_AddWishlist_OwnerIsNullResultIsNull()
        {
            Owner owner = null;
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };

            this.mockOwnerRepository.Setup(o => o.GetOwnerObject("")).Returns(owner);
            this.mockWishlistRepository.Setup(w => w.AddWishlist(It.IsAny<Wishlist>())).Returns(wishlist);

            var result = this.wishlistService.AddWishlist("", WishlistDTOMapper.ObjectToDTO(wishlist));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_AddWishlist_WishlistNullResultIsNull()
        {
            var owner = new Owner
            {
                Name = "Test",
                ExternalId = "Test1",
                Id = 1
            };
            Wishlist wishlist = null;

            this.mockOwnerRepository.Setup(o => o.GetOwnerObject(owner.ExternalId)).Returns(owner);
            this.mockWishlistRepository.Setup(w => w.AddWishlist(It.IsAny<Wishlist>())).Returns(wishlist);

            var result = this.wishlistService.AddWishlist("", WishlistDTOMapper.ObjectToDTO(wishlist));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_AddWishlistItem_ReturnsDTO()
        {
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };
            var item = new WishlistItem
            {
                Code = "Item1",
                Name = "Item1"
            };

            this.mockWishlistRepository.Setup(w => w.AddWishlistItem(wishlist.ExternalId, It.IsAny<WishlistItem>())).Returns(item);

            var result = this.wishlistService.AddWishlistItem(wishlist.ExternalId, WishlistItemDTOMapper.ObjectToDTO(item));

            Assert.AreEqual("Item1", result.Code);
        }

        [TestMethod]
        public void WishlistService_AddWishlistItem_ItemIsNullResultIsNull()
        {
            WishlistItem item = null;
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };

            this.mockWishlistRepository.Setup(w => w.AddWishlistItem(wishlist.ExternalId, item)).Returns(item);

            var result = this.wishlistService.AddWishlistItem(wishlist.ExternalId, WishlistItemDTOMapper.ObjectToDTO(item));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_UpdateWishlistItem_ItemIsNullResultIsNull()
        {
            WishlistItem item = null;
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };

            this.mockWishlistRepository.Setup(w => w.UpdateWishlistItem(item)).Returns(item);

            var result = this.wishlistService.UpdateWishlistItem(wishlist.ExternalId, WishlistItemDTOMapper.ObjectToDTO(item));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_UpdateWishlistItem_WishlistIsNullResultIsNull()
        {
            var item = new WishlistItem
            {
                Code = "Item1",
                Name = "Item1"
            };

            this.mockWishlistRepository.Setup(w => w.UpdateWishlistItem(item)).Returns(item);

            var result = this.wishlistService.UpdateWishlistItem(null, WishlistItemDTOMapper.ObjectToDTO(item));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistService_UpdateWishlistItem_ReturnsDTO()
        {
            var item = new WishlistItem
            {
                Code = "Item1",
                Name = "Item1",
                WishlistId = 1
            };
            var wishlist = new Wishlist
            {
                ExternalId = "list",
                Id = 1,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                OwnerId = 1
            };
            this.mockWishlistRepository.Setup(w => w.UpdateWishlistItem(It.IsAny<WishlistItem>())).Returns(item);

            var result = this.wishlistService.UpdateWishlistItem(wishlist.ExternalId, WishlistItemDTOMapper.ObjectToDTO(item));

            Assert.AreEqual("Item1", result.Code);
        }
    }
}
