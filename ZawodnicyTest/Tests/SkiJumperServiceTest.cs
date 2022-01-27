using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.Test.Tests
{
    [TestClass]
    public class SkiJumperServiceTest
    {
        private readonly ISkiJumperService _skiJumperService;
        private readonly Mock<ISkiJumperRepository> _skiJumperRepositoryMock = new Mock<ISkiJumperRepository>();

        public SkiJumperServiceTest()
        {
            _skiJumperService = new SkiJumperService(_skiJumperRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAsync_ShouldReturnSkiJumper_WhenSkiJumperExists()
        {
            // Arrange
            var skiJumperId = 1;
            var skiJumperRep = new SkiJumper()
            {
                Id = skiJumperId,
                Name = "Joe",
                ForeName = "Smith",
                Country = "USA",
                BirthDate = new DateTime(2000, 3, 1, 7, 0, 0),
                Height = 175,
                Weight = 65
            };

            _skiJumperRepositoryMock.Setup(x => x.GetAsync(skiJumperId))
                .ReturnsAsync(skiJumperRep);

            // Act
            var expected = new SkiJumperDTO()
            {
                Id = skiJumperId,
                Name = "Joe",
                ForeName = "Smith",
                Country = "USA",
                BirthDate = new DateTime(2000, 3, 1, 7, 0, 0),
                Height = 175,
                Weight = 65
            };
            var actual = await _skiJumperService.GetAsync(skiJumperId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public Task GetAsync_ShouldThrowNullReferenceException_WhenSkiJumperDoesNotExist()
        {
            // Arrange
            var skiJumperId = 10;

            _skiJumperRepositoryMock.Setup(x => x.GetAsync(skiJumperId))
                .ThrowsAsync(new NullReferenceException());

            // Act, Assert
            _ = Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await _skiJumperService.GetAsync(skiJumperId));
            return Task.CompletedTask;
        }

        [TestMethod]
        public async Task BrowseAllByFilterAsync_ShouldReturnSkiJumperList_WhenCountryExists()
        {
            // Arrange
            var filterCountry = "USA";

            var skiJumperIdOne = 1;
            var skiJumperRep = new SkiJumper()
            {
                Id = skiJumperIdOne,
                Name = "Joe",
                ForeName = "Smith",
                Country = filterCountry,
                BirthDate = new DateTime(2000, 3, 1, 0, 0, 0),
                Height = 175,
                Weight = 65
            };

            List<SkiJumper> skiJumperListRep = new List<SkiJumper>();
            skiJumperListRep.Add(skiJumperRep);

            _skiJumperRepositoryMock.Setup(x => x.BrowseAllByFilterAsync(filterCountry))
                .ReturnsAsync(skiJumperListRep);

            // Act
            IEnumerable<SkiJumperDTO> skiJumperListDTO = await _skiJumperService.BrowseAllByFilterAsync(filterCountry);
            var expected = new List<SkiJumperDTO>();
            var expectedSkiJumper = new SkiJumperDTO()
            {
                Id = skiJumperIdOne,
                Name = "Joe",
                ForeName = "Smith",
                Country = filterCountry,
                BirthDate = new DateTime(2000, 3, 1, 0, 0, 0),
                Height = 175,
                Weight = 65
            };
            expected.Add(expectedSkiJumper);
            var actual = skiJumperListDTO.ToList();

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public async Task BrowseAllByFilterAsync_ShouldReturnEmptySkiJumperList_WhenCountryDoesNotExist()
        {
            // Arrange
            var filterCountry = "USA";

            List<SkiJumper> skiJumperListRep = new List<SkiJumper>();

            _skiJumperRepositoryMock.Setup(x => x.BrowseAllByFilterAsync(filterCountry))
                .ReturnsAsync(skiJumperListRep);

            // Act
            IEnumerable<SkiJumperDTO> skiJumperListDTO = await _skiJumperService.BrowseAllByFilterAsync(filterCountry);
            var expected = new List<SkiJumperDTO>();
            var actual = skiJumperListDTO.ToList();

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public async Task DelAsync_ShouldDelSkiJumperById()
        {
            // Arrange
            var skiJumperId = 1;
            var skiJumperRep = new SkiJumper()
            {
                Id = skiJumperId,
                Name = "Joe",
                ForeName = "Smith",
                Country = "Brazil",
                BirthDate = new DateTime(1999, 3, 1, 0, 0, 0),
                Height = 175,
                Weight = 69
            };
            _skiJumperRepositoryMock.Setup(x => x.DelAsync(skiJumperRep)).Verifiable();

            // Act
            await _skiJumperService.DelAsync(skiJumperId);

            // Assert
            _skiJumperRepositoryMock.Verify(x => x.DelAsync(It.IsAny<SkiJumper>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateSkiJumper()
        {
            // Arrange
            var skiJumperId = 1;
            var skiJumperRep = new SkiJumper()
            {
                Id = skiJumperId,
                Name = "Vladimir",
                ForeName = "Kakaszenko",
                Country = "Russia",
                BirthDate = new DateTime(1999, 3, 1, 0, 0, 0),
                Height = 169,
                Weight = 63
            };

            _skiJumperRepositoryMock.Setup(x => x.UpdateAsync(skiJumperRep)).Verifiable();

            // Act
            var skiJumperUpdate = new UpdateSkiJumper()
            {
                Name = "Vladimir",
                ForeName = "Kakaszenko",
                Country = "Russia"
            };
            await _skiJumperService.UpdateAsync(skiJumperId, skiJumperUpdate);

            // Assert
            _skiJumperRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<SkiJumper>()), Times.Once());
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddSkiJumper()
        {
            // Arrange
            var skiJumperId = 1;
            var skiJumperRep = new SkiJumper()
            {
                Id = skiJumperId,
                Name = "Vladimir",
                ForeName = "Kakaszenko",
                Country = "Russia",
                BirthDate = default,
                Height = 0,
                Weight = 0
            };

            _skiJumperRepositoryMock.Setup(x => x.AddAsync(skiJumperRep)).Verifiable();

            // Act
            var skiJumperCreate = new CreateSkiJumper()
            {
                Name = "Vladimir",
                ForeName = "Kakaszenko",
                Country = "Russia"
            };
            await _skiJumperService.AddAsync(skiJumperCreate);

            // Assert
            _skiJumperRepositoryMock.Verify(x => x.AddAsync(It.IsAny<SkiJumper>()), Times.Once());
        }
    }
}