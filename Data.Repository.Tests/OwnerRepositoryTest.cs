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
    public class OwnerRepositoryTest
    {
        private Mock<WishlistContext> mockContext;

        private OwnerRepository ownerRepository;

        private Mock<DbSet<Owner>> mockSet;

        private IQueryable<Owner> owners;

        [TestInitialize]
        public void TestInitialize()
        {
            this.owners = new List<Owner>
            {
                new Owner
                {
                    Name = "Test",
                    ExternalId = "Test1",
                    DateCreated = new DateTime(2020, 2, 13),
                    DateUpdated = new DateTime(2020, 3, 2)
                },
                new Owner
                {
                    Name = "Teste2",
                    ExternalId = "Teste21",
                    DateCreated = new DateTime(2019, 12, 24),
                    DateUpdated = new DateTime(2020, 1, 10)
                }
            }.AsQueryable();

            this.mockContext = new Mock<WishlistContext>();

            this.mockSet = new Mock<DbSet<Owner>>() { CallBase = true };

            this.mockSet.As<IQueryable<Owner>>().Setup(m => m.Provider).Returns(this.owners.Provider);
            this.mockSet.As<IQueryable<Owner>>().Setup(m => m.Expression).Returns(this.owners.Expression);
            this.mockSet.As<IQueryable<Owner>>().Setup(m => m.ElementType).Returns(this.owners.ElementType);
            this.mockSet.As<IQueryable<Owner>>().Setup(m => m.GetEnumerator()).Returns(this.owners.GetEnumerator());

            this.mockContext.Setup(m => m.Owners).Returns(this.mockSet.Object);

            this.ownerRepository = new OwnerRepository(this.mockContext.Object);
        }

        [TestMethod]
        public void OwnerRepository_GetOwners_ReturnsList()
        {
            var result = this.ownerRepository.GetAllOwners();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void OwnerRepository_GetOwner_ReturnsObject()
        {
            var result = this.ownerRepository.GetOwnerObject(this.owners.ElementAt(0).ExternalId);

            Assert.AreEqual("Test1", result.ExternalId);
        }

        [TestMethod]
        public void OwnerRepository_GetOwner_ReturnsNull()
        {
            var result = this.ownerRepository.GetOwnerObject(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void OwnerRepository_DeleteOwner_ReturnsObject()
        {
            this.mockSet.Setup(m => m.Remove(It.IsAny<Owner>())).Returns(new Owner());

            var result = this.ownerRepository.DeleteOwner(this.owners.ElementAt(0).ExternalId);

            Assert.AreEqual("Test1", result.ExternalId);
        }

        [TestMethod]
        public void OwnerRepository_DeleteOwner_ReturnsNull()
        {
            this.mockSet.Setup(m => m.Remove(It.IsAny<Owner>())).Returns(new Owner());

            var result = this.ownerRepository.DeleteOwner(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void OwnerRepository_AddOwner_ReturnsObject()
        {
            this.mockSet.Setup(m => m.Add(It.IsAny<Owner>())).Returns(new Owner());

            var result = this.ownerRepository.AddOwner(new Owner { ExternalId = "Test1" });

            Assert.AreEqual("Test1", result.ExternalId);
        }

        [TestMethod]
        public void OwnerRepository_AddOwner_ReturnsNull()
        {
            this.mockSet.Setup(m => m.Add(It.IsAny<Owner>())).Returns(new Owner());

            var result = this.ownerRepository.AddOwner(null);

            Assert.IsNull(result);
        }
    }
}
