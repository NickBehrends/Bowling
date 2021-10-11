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
using static Bowling.Application.Queries.GetCurrentGame;

namespace Bowling.Tests.Application
{
    public class GetCurrentGameTests
    {
        [Fact]
        public void GetCurrentGameWhenGameDoesNotExists()
        {
            var queryRepoMock = new Mock<IBowlingQueriesRepository>();
            queryRepoMock.Setup(x => x.DoesActiveGameExist(It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var sut = new Handler(queryRepoMock.Object);

            Assert.ThrowsAsync<NoGameInProgressException>(async () => await sut.Handle(new Query(),
                CancellationToken.None));
        }
    }
}
