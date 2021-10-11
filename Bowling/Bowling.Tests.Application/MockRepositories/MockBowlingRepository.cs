using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application;
using Bowling.Application.Repositories;
using Bowling.Tests.Application.MockRepositories.MockTables;

namespace Bowling.Tests.Application.MockRepositories
{
    public class MockBowlingRepository : IBowlingCommandsRepository
    {
        public ICollection<MockGame> Games { get; set; }

        public MockBowlingRepository()
        {
            Games = new List<MockGame>();
        }

        public async Task CreateGame(Guid id, ICollection<string> players, string name, CancellationToken? cancellationToken = null)
        {
            await Task.Run(() =>
            {
                Games.Add(new MockGame(id, name, players));
            });
        }

        public Task ThrowBall(ThrowBall.Command request, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
