using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Model.Tests
{
    [TestClass]
    public class WishlistItemTest
    {
        WishlistItem item;
        List<WishlistItemAttribute> attributes;

        [TestInitialize]
        public void TestInitialize()
        {
            this.attributes = new List<WishlistItemAttribute>();
            this.item = new WishlistItem();
        }

        [TestMethod]
        public void WishlistItem_GettersAndSetters()
        {
            this.item.Price = 20;
            this.item.Name = "Item";
            this.item.Code = "Item12";
            this.item.WishlistId = 1;
            this.item.Id = 1;
            this.item.Attributes = this.attributes;
            this.item.DateCreated = new DateTime(2018, 8, 11);
            this.item.DateUpdated = new DateTime(2019, 10, 26);

            double price = this.item.Price;
            string name = this.item.Name;
            string code = this.item.Code;
            int id = this.item.Id;
            int wishlistID = this.item.WishlistId;
            List<WishlistItemAttribute> attributes = this.item.Attributes;
            DateTime dateCreated = this.item.DateCreated;
            DateTime dateUpdated = this.item.DateUpdated;

            Assert.AreEqual(20, price);
            Assert.AreEqual("Item12", code);
            Assert.AreEqual(1, wishlistID);
            Assert.AreEqual("Item", name);
            Assert.AreEqual(1, id);
            Assert.AreEqual(this.attributes, attributes);
            Assert.AreEqual(new DateTime(2018, 8, 11), dateCreated);
            Assert.AreEqual(new DateTime(2019, 10, 26), dateUpdated);
        }
    }
}
