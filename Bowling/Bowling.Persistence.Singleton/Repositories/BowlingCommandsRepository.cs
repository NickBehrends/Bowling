using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application;
using Bowling.Application.Repositories;
using Bowling.Persistence.Singleton.Tables;

namespace Bowling.Persistence.Singleton.Repositories
{
    public class BowlingCommandsRepository : IBowlingCommandsRepository
    {
        public async Task CreateGame(Guid id, ICollection<string> players, string name, CancellationToken? cancellationToken = null)
        {
            await Task.Run(() =>
            {
                var playersToCreate = new List<Player>();

                foreach (var player in players)
                {
                    playersToCreate.Add(new Player(
                        Id: Guid.NewGuid(),
                        Throws: new List<Throw>(),
                        Name: player,
                        IsGameCompleted: false,
                        TurnOrder: playersToCreate.Count + 1));
                }

                var game = new Game(
                    Id: id, 
                    Name: name, 
                    Players: playersToCreate, 
                    IsActive: true);

                Database.Instance.Games.Add(game);
            });
        }

        public async Task ThrowBall(ThrowBall.Command request, CancellationToken? cancellationToken = null)
        {
            await Task.Run(() =>
            {
                var player = Database.Instance.Games.SelectMany(x => x.Players).FirstOrDefault(x =>
                    string.Equals(x.Name, request.Player, StringComparison.OrdinalIgnoreCase));
                player!.Throws.Add(new Throw(request.Pins));
            });
        }
    }
}
