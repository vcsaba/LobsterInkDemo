using LobsterInk.Adventure.Business.Services;
using LobsterInk.Adventure.Data.Factories;
using LobsterInk.Adventure.Data.Repositories;
using LobsterInk.Adventure.Shared.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LobsterInk.Adventure.Tests.Business.Services
{
    public class TreeServiceTest
    {
        [Test]
        public async Task AddNodeAsyncTest()
        {
            // Arrange
            var expectedResult = "test-result";

            Mock<INodeRepository<Node>> nodeRepository = new Mock<INodeRepository<Node>>();
            nodeRepository.Setup(y => y.Add(It.IsAny<Node>())).Returns(expectedResult);

            Mock<INodeRepositoryFactory> repositoryFactoryMock = new Mock<INodeRepositoryFactory>();
            repositoryFactoryMock.Setup(y => y.CreateRepository())
                .Returns(nodeRepository.Object);

            var treeService = new TreeService(repositoryFactoryMock.Object);

            // Act
            var result = await treeService.AddNodeAsync(new Node());

            // Assert
            Assert.AreEqual(expectedResult, result);
            repositoryFactoryMock.Verify(y => y.CreateRepository(), Times.Once);
            nodeRepository.Verify(y => y.Add(It.IsAny<Node>()), Times.Once);
        }

        [Test]
        public async Task GetNodeAsyncTest()
        {
            // Arrange
            var expectedResult = new Node { Id = "test-id" };

            Mock<INodeRepository<Node>> nodeRepository = new Mock<INodeRepository<Node>>();
            nodeRepository.Setup(y => y.Get(It.Is<string>(y => expectedResult.Id.Equals(y)))).Returns(expectedResult);

            Mock<INodeRepositoryFactory> repositoryFactoryMock = new Mock<INodeRepositoryFactory>();
            repositoryFactoryMock.Setup(y => y.CreateRepository())
                .Returns(nodeRepository.Object);

            var treeService = new TreeService(repositoryFactoryMock.Object);

            // Act
            var result = await treeService.GetNodeAsync(expectedResult.Id);

            // Assert
            Assert.AreEqual(expectedResult, result);
            repositoryFactoryMock.Verify(y => y.CreateRepository(), Times.Once);
            nodeRepository.Verify(y => y.Get(It.Is<string>(y => expectedResult.Id.Equals(y))), Times.Once);
        }

        [Test]
        public async Task UpdateNodeAsyncTest()
        {
            // Arrange
            var expectedResult = new Node();

            Mock<INodeRepository<Node>> nodeRepository = new Mock<INodeRepository<Node>>();
            nodeRepository.Setup(y => y.Update(It.IsAny<Node>())).Returns(expectedResult);

            Mock<INodeRepositoryFactory> repositoryFactoryMock = new Mock<INodeRepositoryFactory>();
            repositoryFactoryMock.Setup(y => y.CreateRepository())
                .Returns(nodeRepository.Object);

            var treeService = new TreeService(repositoryFactoryMock.Object);

            // Act
            var result = await treeService.UpdateNodeAsync(new Node());

            // Assert
            Assert.AreEqual(expectedResult, result);
            repositoryFactoryMock.Verify(y => y.CreateRepository(), Times.Once);
            nodeRepository.Verify(y => y.Update(It.IsAny<Node>()), Times.Once);
        }

        [Test]
        public async Task DeleteNodeTest()
        {
            // Arrange
            Mock<INodeRepository<Node>> nodeRepository = new Mock<INodeRepository<Node>>();
            nodeRepository.Setup(y => y.Delete(It.IsAny<string>())).Callback(() => { });

            Mock<INodeRepositoryFactory> repositoryFactoryMock = new Mock<INodeRepositoryFactory>();
            repositoryFactoryMock.Setup(y => y.CreateRepository())
                .Returns(nodeRepository.Object);

            var treeService = new TreeService(repositoryFactoryMock.Object);

            // Act
            await treeService.DeleteNodeAsync("id");

            // Assert
            repositoryFactoryMock.Verify(y => y.CreateRepository(), Times.Once);
            nodeRepository.Verify(y => y.Delete(It.IsAny<string>()), Times.Once);
        }
    }
}
