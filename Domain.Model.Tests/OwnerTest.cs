using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Model.Tests
{
    [TestClass]
    public class OwnerTest
    {
        Owner owner;
        Wishlist wishlist;

        [TestInitialize]
        public void TestInitialize()
        {
            this.owner = new Owner();
            this.wishlist = new Wishlist();
        }

        [TestMethod]
        public void Owner_GettersAndSetters()
        {
            this.owner.ExternalId = "Test1";
            this.owner.Name = "Test";
            this.owner.Id = 1;
            this.owner.DateCreated = new DateTime(2019, 6, 11);
            this.owner.DateUpdated = new DateTime(2020, 4, 21);

            string externalId = this.owner.ExternalId;
            string name = this.owner.Name;
            int id = this.owner.Id;
            DateTime created = this.owner.DateCreated;
            DateTime updated = this.owner.DateUpdated;

            Assert.AreEqual("Test1", externalId);
            Assert.AreEqual("Test", name);
            Assert.AreEqual(1, id);
            Assert.AreEqual(new DateTime(2019, 6, 11), created);
            Assert.AreEqual(new DateTime(2020, 4, 21), updated);
        }

        [TestMethod]
        public void Owner_AddWishlist()
        {
            this.wishlist.ExternalId = "Teste";

            this.owner.AddWishlist(this.wishlist);

            var added = this.owner.Wishlists.Find(w => w.ExternalId == this.wishlist.ExternalId);

            Assert.AreEqual(this.wishlist.ExternalId, added.ExternalId);
        }

        [TestMethod]
        public void Owner_GetOrCreateWishlist_ReturnsWishlist()
        {
            this.wishlist.ExternalId = "Test";
            this.owner.AddWishlist(this.wishlist);

            var result = this.owner.GetOrCreateWishlist("Test");

            Assert.AreEqual(this.wishlist, result);
        }

        [TestMethod]
        public void Owner_RemoveWishlist()
        {
            this.wishlist.ExternalId = "Teste";

            this.owner.AddWishlist(this.wishlist);

            this.owner.RemoveWishlist(this.wishlist);

            Assert.AreEqual(0, this.owner.Wishlists.Count);
        }

        [TestMethod]
        public void Owner_RemoveWishlist_DoesntRemoveWhenWishlistIsNull()
        {
            this.wishlist.ExternalId = "Teste";

            this.owner.AddWishlist(this.wishlist);

            this.owner.RemoveWishlist(null);

            Assert.AreNotEqual(0, this.owner.Wishlists.Count);
        }
    }
}
