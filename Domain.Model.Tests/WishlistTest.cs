using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Model.Tests
{
    [TestClass]
    public class WishlistTest
    {
        Wishlist wishlist;
        List<WishlistItem> wishlistItems;
        WishlistItem wishlistItem;

        [TestInitialize]
        public void TestInitialize()
        {
            this.wishlist = new Wishlist
            {
                ExternalId = "Test"
            };
            this.wishlistItems = new List<WishlistItem>();
            this.wishlistItem = new WishlistItem()
            {
                Code = "ItemCode"
            };
        }

        [TestMethod()]
        public void Wishlist_GettersAndSetters()
        {
            this.wishlist.ExternalId = "list";
            this.wishlist.OwnerId = 1;
            this.wishlist.Id = 1;
            this.wishlist.WishlistItems = this.wishlistItems;

            string externalId = this.wishlist.ExternalId;
            int ownerId = this.wishlist.OwnerId;
            int id = this.wishlist.Id;
            List<WishlistItem> wishlistItems = this.wishlist.WishlistItems;

            Assert.AreEqual("list", externalId);
            Assert.AreEqual(1, ownerId);
            Assert.AreEqual(1, id);
            Assert.AreEqual(this.wishlistItems, wishlistItems);
        }

        [TestMethod()]
        public void Wishlist_AddOrUpdateWishlistItem_AddsItem()
        {
            this.wishlist.AddOrUpdateWishlistItem(this.wishlistItem);

            Assert.AreEqual(1, this.wishlist.WishlistItems.Count);
        }

        [TestMethod]
        public void Wishlist_AddOrUpdateWishlistItem_UpdateItem()
        {
            this.wishlist.AddOrUpdateWishlistItem(this.wishlistItem);

            this.wishlistItem.Name = "NewName";

            this.wishlist.AddOrUpdateWishlistItem(this.wishlistItem);
            Assert.AreEqual("NewName", this.wishlist.WishlistItems.Find(x => x.Id == this.wishlistItem.Id).Name);
        }

        [TestMethod]
        public void Wishlist_RemoveWishlistItem()
        {
            this.wishlist.AddOrUpdateWishlistItem(this.wishlistItem);

            Assert.AreEqual(1, this.wishlist.WishlistItems.Count);

            this.wishlist.RemoveWishlistItem(this.wishlistItem);

            Assert.AreEqual(0, this.wishlist.WishlistItems.Count);
        }
    }
}
