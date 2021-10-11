using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bowling.Application.Repositories
{
    public interface IBowlingCommandsRepository
    {
        Task CreateGame(Guid id, ICollection<string> players, string name, CancellationToken? cancellationToken = null);
        Task ThrowBall(ThrowBall.Command request, CancellationToken? cancellationToken = null);
    }
}
