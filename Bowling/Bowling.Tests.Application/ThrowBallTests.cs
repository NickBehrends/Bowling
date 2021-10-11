using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application;
using Bowling.Application.Exceptions;
using Bowling.Application.Repositories;
using Moq;
using Xunit;

namespace Bowling.Tests.Application
{
    public class ThrowBallTests
    {
        [Fact]
        public void KnockDownTooManyPins()
        {
            var commandRepoMock = new Mock<IBowlingCommandsRepository>();
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();

            var sut = new ThrowBall.Handler(commandRepoMock.Object, queryRepoMock.Object);
            Assert.ThrowsAsync<TooManyPinsKnockedException>(async () =>
                await sut.Handle(new ThrowBall.Command(Guid.NewGuid(), 11), CancellationToken.None));
        }

        [Fact]
        public void WrongPlayerThrewTheBall()
        {
            var commandRepoMock = new Mock<IBowlingCommandsRepository>();
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();
            queryRepoMock.Setup(x => x.DoesUserExist(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var sut = new ThrowBall.Handler(commandRepoMock.Object, queryRepoMock.Object);
            Assert.ThrowsAsync<UserNotFoundException>(async () =>
                await sut.Handle(new ThrowBall.Command(Guid.NewGuid(), 10), CancellationToken.None));
        }
    }
}
