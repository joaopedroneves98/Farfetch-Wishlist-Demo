using System;
using System.Collections.Generic;
using Application.DTO;
using Application.Services.Implementations;
using Data.Repository.Interfaces.Repositories;
using Domain.Model;
using Domain.Services.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Services.Tests
{
    [TestClass]
    public class OwnerServiceTest
    {
        private Mock<IOwnerRepository> mockOwnerRepository;

        private OwnerService ownerService;

        [TestInitialize]
        public void Initializer()
        {
            this.mockOwnerRepository = new Mock<IOwnerRepository>();
            this.ownerService = new OwnerService(this.mockOwnerRepository.Object);
        }

        [TestMethod]
        public void OwnerService_GetOwner_IDsAreEqual()
        {
            var owner = new Owner
            {
                Name = "Test",
                ExternalId = "Test1"
            };
            this.mockOwnerRepository.Setup(o => o.GetOwnerObject(owner.ExternalId)).Returns(owner);

            var result = this.ownerService.GetOwner(owner.ExternalId);

            Assert.AreEqual(owner.ExternalId, result.ExternalID);
        }

        [TestMethod]
        public void OwnerService_GetOwner_ResultIsNull()
        {
            Owner owner = null;
            this.mockOwnerRepository.Setup(o => o.GetOwnerObject("")).Returns(owner);

            var result = this.ownerService.GetOwner("");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void OwnerService_DeleteOwner_DeletedIdIsEqual()
        {
            var owner = new Owner
            {
                Name = "Delete Me",
                ExternalId = "Delete"
            };

            this.mockOwnerRepository.Setup(o => o.DeleteOwner(owner.ExternalId)).Returns(owner);

            var result = this.ownerService.DeleteOwner(owner.ExternalId);

            Assert.AreEqual(owner.ExternalId, result.ExternalID);
        }

        [TestMethod]
        public void OwnerService_DeleteOwner_ResultIsNull()
        {
            Owner owner = null;
            this.mockOwnerRepository.Setup(o => o.DeleteOwner("")).Returns(owner);

            var result = this.ownerService.DeleteOwner("");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void OwnerService_GetAllOwners_ReturnsList()
        {
            var actual = new List<Owner> {
                new Owner{ Name = "Test1" },
                new Owner{ Name = "Test2" }
            };

            var expected = new List<OwnerDTO>();
            foreach (var o in actual)
            {
                expected.Add(OwnerDTOMapper.ObjectToDTO(o));
            }

            this.mockOwnerRepository.Setup(m => m.GetAllOwners()).Returns(actual);

            var result = this.ownerService.GetAllOwners();

            Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void OwnerService_AddOwner_ReturnsDTO()
        {
            var dto = new OwnerDTO
            {
                Id = 1,
                Name = "Test",
                ExternalID = "Test1",
            };
            var owner = OwnerDTOMapper.DTOToObject(dto);

            this.mockOwnerRepository.Setup(o => o.AddOwner(It.IsAny<Owner>())).Returns(owner);

            var result = this.ownerService.AddOwner(dto);

            Assert.AreEqual(owner.ExternalId, result.ExternalID);
        }

        [TestMethod]
        public void OwnerService_UpdateOwner_ReturnsDTO()
        {
            var dto = new OwnerDTO
            {
                Id = 1,
                Name = "Test",
                ExternalID = "Test1",
            };
            var owner = OwnerDTOMapper.DTOToObject(dto);

            this.mockOwnerRepository.Setup(o => o.UpdateOwner(It.IsAny<Owner>())).Returns(owner); 

            var result = this.ownerService.UpdateOwner(dto);

            Assert.AreEqual(owner.ExternalId, result.ExternalID);
        }
    }
}