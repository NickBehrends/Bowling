using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.Exceptions;
using Bowling.Application.Repositories;
using Bowling.Tests.Application.MockRepositories;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
using Moq;
using Xunit;
using static Bowling.Application.CreateGame;

namespace Bowling.Tests.Application
{
    public class CreateGameTests
    {
        [Fact]
        public async void CreatePersistsAndReturnsUniqueId()
        {
            var commandRepoMock = new MockBowlingRepository();
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();
            queryRepoMock.Setup(x => x.DoesActiveGameExist(It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var gameName = "New Game";
            var players = new List<string>
            {
                "Nick"
            };
            var sut = new Handler(commandRepoMock, queryRepoMock.Object);
            var result = await sut.Handle(new Command(gameName, players), CancellationToken.None);

            var createdRecord = commandRepoMock.Games.FirstOrDefault();
            Assert.NotEqual(Guid.Empty, result);
            Assert.NotNull(createdRecord);
            Assert.Equal(gameName, createdRecord.Name);
            Assert.Equal(players, createdRecord.Players);
            Assert.NotEqual(Guid.Empty, createdRecord.Id);
        }

        [Theory]
        [MemberData(nameof(ParameterProvider.InvalidLaneCreation), MemberType = typeof(ParameterProvider))]
        public void CreateWithInvalidParameters(string gameName, ICollection<string> players)
        {
            var commandRepoMock = new Mock<IBowlingCommandsRepository>();
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();
            queryRepoMock.Setup(x => x.DoesActiveGameExist(It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var sut = new Handler(commandRepoMock.Object, queryRepoMock.Object);

            Assert.ThrowsAsync<ArgumentException>(async () => await sut.Handle(new Command(gameName, players),
                CancellationToken.None));
        }

        [Fact]
        public void CreateWhenGameAlreadyExists()
        {
            var commandRepoMock = new Mock<IBowlingCommandsRepository>();
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();
            queryRepoMock.Setup(x => x.DoesActiveGameExist(It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var gameName = "New Game";
            var players = new List<string>
            {
                "Nick"
            };

            var sut = new Handler(commandRepoMock.Object, queryRepoMock.Object);
            Assert.ThrowsAsync<GameAlreadyInProgressException>(async () => await sut.Handle(new Command(gameName, players),
                CancellationToken.None));
        }
    }
}
