using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.AggregateModels;
using Bowling.Application.Repositories;

namespace Bowling.Persistence.Singleton.Repositories
{
    public class BowlingQueriesRepository : IBowlingQueriesRepository
    {
        public async Task<Game> GetActiveGame(CancellationToken? cancellationToken = null)
        {
            return await Task.Run(() =>
            {
                var (id, name, players, _, round) = Database.Instance.Games.FirstOrDefault(x => x.IsActive);
                return new Game(name, id, players.Select(x => new Player(x.Name, x.Id, x.Throws.Select(y => y.Pins).ToList(), 0, x.TurnOrder)).ToList(), round);
            });
        }

        public async Task<bool> DoesActiveGameExist(CancellationToken? cancellationToken = null)
        {
            return await Task.Run(() => Database.Instance.Games.Any(x => x.IsActive));
        }

        public async Task<bool> DoesUserExist(string player, CancellationToken? cancellationToken = null)
        {
            return await Task.Run(() =>
            {
                return Database.Instance.Games.Any(game => game.Players.Any(gamePlayer =>
                    string.Equals(gamePlayer.Name, player, StringComparison.OrdinalIgnoreCase)));
            });
        }
    }
}
