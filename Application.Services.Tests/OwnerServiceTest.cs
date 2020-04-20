using System;
using Application.Services.Implementations;
using Data.Repository.Interfaces.Repositories;
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
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
