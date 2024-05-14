using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_test
{
    public class OwnerRepositoryTests
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;
        public OwnerRepositoryTests()
        {
            
            factoryContextMock = new Mock<FactoryContext>();

           
            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }
        [Fact]
        [Trait("Author", "User")]
        public void AddOwner_ValidOwner_AddedSuccessfully()
        {
           
            var owner = new Owner() { Id = 1, Name = "carol emad" };

            
            var ownersDbSetMock = new Mock<DbSet<Owner>>();

            
            factoryContextMock.Setup(fcm => fcm.Owners).Returns(ownersDbSetMock.Object);

           
            bool result = ownerRepository.AddOwner(owner);

            
            Assert.True(result);
            factoryContextMock.Verify(fcm => fcm.SaveChanges(), Times.Once); 
            ownersDbSetMock.Verify(odsm => odsm.Add(It.IsAny<Owner>()), Times.Once); 
            ownersDbSetMock.Verify(odsm => odsm.Add(owner), Times.Once); 
        }


    }
}
