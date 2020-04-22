using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Model.Tests
{
    [TestClass]
    public class WishlistItemAttributeTest
    {
        WishlistItemAttribute attribute;

        [TestInitialize]
        public void TestInitialize()
        {
            this.attribute = new WishlistItemAttribute();
        }

        [TestMethod()]
        public void WishlistItemAttribute_GettersAndSetters()
        {
            this.attribute.Key = "Color";
            this.attribute.Value = "Red";
            this.attribute.WishlistItemId = 2121;
            this.attribute.DateCreated = new DateTime(2020, 4, 10);
            this.attribute.DateUpdated = new DateTime(2020, 4, 20);

            var key = this.attribute.Key;
            var value = this.attribute.Value;
            var itemID = this.attribute.WishlistItemId;
            var dateCreated = this.attribute.DateCreated;
            var dateUpdated = this.attribute.DateUpdated;

            Assert.AreEqual("Color", key);
            Assert.AreEqual("Red", value);
            Assert.AreEqual(2121, itemID);
            Assert.AreEqual(new DateTime(2020, 4, 10), dateCreated);
            Assert.AreEqual(new DateTime(2020, 4, 20), dateUpdated);
        }
    }
}
