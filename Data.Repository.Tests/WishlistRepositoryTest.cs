using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Repository.Models;
using Data.Repository.Repositories;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Data.Repository.Tests
{
    [TestClass]
    public class WishlistRepositoryTest
    {
        private WishlistRepository wishlistRepository;

        private Mock<WishlistContext> mockContext;

        private IQueryable<Wishlist> wishlists;

        private IQueryable<WishlistItem> items;

        private IQueryable<WishlistItemAttribute> attributes;

        private Mock<DbSet<Wishlist>> mockSetWishlist;

        private Mock<DbSet<WishlistItem>> mockSetWishlistItem;

        private Mock<DbSet<WishlistItemAttribute>> mockSetWishlistItemAttribute;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockContext = new Mock<WishlistContext>();

            this.wishlists = new List<Wishlist> {
            new Wishlist
            {
                ExternalId = "Wishlist1",
                DateCreated = new DateTime(2019, 11, 11),
                DateUpdated = new DateTime(2019, 11, 11),

            },
            new Wishlist
            {
                ExternalId = "Wishlist2",
                DateCreated = new DateTime(2020, 1, 11),
                DateUpdated = new DateTime(2020, 2, 11)
            }
            }.AsQueryable();

            this.mockSetWishlist = new Mock<DbSet<Wishlist>>() { CallBase = true };

            this.mockSetWishlist.As<IQueryable<Wishlist>>().Setup(m => m.Provider).Returns(this.wishlists.Provider);
            this.mockSetWishlist.As<IQueryable<Wishlist>>().Setup(m => m.Expression).Returns(this.wishlists.Expression);
            this.mockSetWishlist.As<IQueryable<Wishlist>>().Setup(m => m.ElementType).Returns(this.wishlists.ElementType);
            this.mockSetWishlist.As<IQueryable<Wishlist>>().Setup(m => m.GetEnumerator()).Returns(this.wishlists.GetEnumerator());

            this.mockContext.Setup(m => m.Wishlists).Returns(this.mockSetWishlist.Object);

            this.items = new List<WishlistItem> {
            new WishlistItem
            {
                Id = 1,
                Name = "Item1",
                Code = "Item1",
                DateCreated = new DateTime(2020, 1, 12),
                DateUpdated = new DateTime(2020, 3, 11),

            },
            new WishlistItem
            {
                Id = 2,
                Name = "Item2",
                Code = "Item2",
                DateCreated = new DateTime(2017, 11, 11),
                DateUpdated = new DateTime(2018, 12, 20)
            }
            }.AsQueryable();

            this.mockSetWishlistItem = new Mock<DbSet<WishlistItem>>() { CallBase = true };

            this.mockSetWishlistItem.As<IQueryable<WishlistItem>>().Setup(m => m.Provider).Returns(this.items.Provider);
            this.mockSetWishlistItem.As<IQueryable<WishlistItem>>().Setup(m => m.Expression).Returns(this.items.Expression);
            this.mockSetWishlistItem.As<IQueryable<WishlistItem>>().Setup(m => m.ElementType).Returns(this.items.ElementType);
            this.mockSetWishlistItem.As<IQueryable<WishlistItem>>().Setup(m => m.GetEnumerator()).Returns(this.items.GetEnumerator());

            this.mockContext.Setup(m => m.WishlistItems).Returns(this.mockSetWishlistItem.Object);

            this.attributes = new List<WishlistItemAttribute>()
            {
                new WishlistItemAttribute {
                    WishlistItemId = 1
                }
            }.AsQueryable();


            this.mockSetWishlistItemAttribute = new Mock<DbSet<WishlistItemAttribute>>() { CallBase = true };

            this.mockSetWishlistItemAttribute.As<IQueryable<WishlistItemAttribute>>().Setup(m => m.Provider).Returns(this.attributes.Provider);
            this.mockSetWishlistItemAttribute.As<IQueryable<WishlistItemAttribute>>().Setup(m => m.Expression).Returns(this.attributes.Expression);
            this.mockSetWishlistItemAttribute.As<IQueryable<WishlistItemAttribute>>().Setup(m => m.ElementType).Returns(this.attributes.ElementType);
            this.mockSetWishlistItemAttribute.As<IQueryable<WishlistItemAttribute>>().Setup(m => m.GetEnumerator()).Returns(this.attributes.GetEnumerator());

            this.mockContext.Setup(m => m.WishlistItemAttributes).Returns(this.mockSetWishlistItemAttribute.Object);

            this.wishlistRepository = new WishlistRepository(this.mockContext.Object);
        }

        [TestMethod]
        public void WishlistRepository_GetWishlists_ReturnsList()
        {
            var result = this.wishlistRepository.GetWishlists();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void WishlistRepository_GetWishlist_ReturnsNull()
        {
            var result = this.wishlistRepository.GetWishlist(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_GetWishlist_ReturnsList()
        {
            var result = this.wishlistRepository.GetWishlist(this.wishlists.ElementAt(0).ExternalId);

            Assert.AreEqual("Wishlist1", result.ExternalId);
        }

        [TestMethod]
        public void WishlistRepository_DeleteWishlist_ReturnsList()
        {
            this.mockSetWishlist.Setup(m => m.Remove(It.IsAny<Wishlist>())).Returns(new Wishlist());

            var result = this.wishlistRepository.DeleteWishlist(this.wishlists.ElementAt(0).ExternalId);

            Assert.AreEqual("Wishlist1", result.ExternalId);
        }

        [TestMethod]
        public void WishlistRepository_DeleteWishlist_ReturnsNull()
        {
            this.mockSetWishlist.Setup(m => m.Remove(It.IsAny<Wishlist>())).Returns(new Wishlist());

            var result = this.wishlistRepository.DeleteWishlist(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_AddWishlist_ReturnList()
        {
            this.mockSetWishlist.Setup(m => m.Add(It.IsAny<Wishlist>())).Returns(new Wishlist());

            var result = this.wishlistRepository.AddWishlist(new Wishlist { ExternalId = "test" });

            Assert.AreEqual("test", result.ExternalId);
        }

        [TestMethod]
        public void WishlistRepository_AddWishlist_ReturnNull()
        {
            this.mockSetWishlist.Setup(m => m.Add(It.IsAny<Wishlist>())).Returns(new Wishlist());

            var result = this.wishlistRepository.AddWishlist(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_GetAllItems_ReturnsList()
        {
            var result = this.wishlistRepository.GetAllItems();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void WishlistRepository_GetWishlistItem_ReturnsObject()
        {
            var result = this.wishlistRepository.GetWishlistItem(this.items.ElementAt(0).Code);

            Assert.AreEqual("Item1", result.Code);
        }

        [TestMethod]
        public void WishlistRepository_GetWishlistItem_ReturnsNull()
        {
            var result = this.wishlistRepository.GetWishlistItem(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_DeleteWishlistItem_ReturnsObject()
        {
            this.mockSetWishlistItem.Setup(m => m.Remove(It.IsAny<WishlistItem>())).Returns(new WishlistItem());

            var result = this.wishlistRepository.DeleteWishlistItem(this.wishlists.ElementAt(0).ExternalId, this.items.ElementAt(0).Code);

            Assert.AreEqual("Item1", result.Code);
        }

        [TestMethod]
        public void WishlistRepository_DeleteWishlistItem_ReturnsNull()
        {
            this.mockSetWishlistItem.Setup(m => m.Remove(It.IsAny<WishlistItem>())).Returns(new WishlistItem());

            var result = this.wishlistRepository.DeleteWishlistItem(null, null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_AddWishlistItem_ReturnsObject()
        {
            this.mockSetWishlistItem.Setup(m => m.Add(It.IsAny<WishlistItem>())).Returns(new WishlistItem { Code = "test" });

            var result = this.wishlistRepository.AddWishlistItem("Wishlist1", new WishlistItem { Code = "test" });

            Assert.AreEqual("test", result.Code);
        }

        [TestMethod]
        public void WishlistRepository_AddWishlistItem_ReturnsNull()
        {
            this.mockSetWishlistItem.Setup(m => m.Add(It.IsAny<WishlistItem>())).Returns(new WishlistItem { Code = "test" });

            var result = this.wishlistRepository.AddWishlistItem(null, new WishlistItem { Code = "test" });

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WishlistRepository_EmptyWishlist()
        {
            this.wishlists.ElementAt(0).WishlistItems.Add(this.items.ElementAt(0));
            var result = this.wishlistRepository.EmptyWishlist(this.wishlists.ElementAt(0).ExternalId);

            Assert.AreEqual(0, this.wishlists.ElementAt(0).WishlistItems.Count);
        }
    }
}
