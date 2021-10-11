using System;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.AggregateModels;

namespace Bowling.Application.Repositories
{
    public interface IBowlingQueriesRepository
    {
        Task<Game> GetActiveGame(CancellationToken? cancellationToken = null);
        Task<bool> DoesActiveGameExist(CancellationToken? cancellationToken = null);
        Task<bool> DoesUserExist(string player, CancellationToken? cancellationToken = null);
    }
}
