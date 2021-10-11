using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.AggregateModels;
using Bowling.Application.Repositories;
using MediatR;

namespace Bowling.Application.Queries
{
    public class WhosTurnIsIt
    {
        public record Query : IRequest<string>;

        public class Handler : IRequestHandler<Query, string>
        {
            private readonly IBowlingQueriesRepository _queriesRepository;

            public Handler(IBowlingQueriesRepository queriesRepository)
            {
                _queriesRepository = queriesRepository;
            }

            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                var game = await _queriesRepository.GetActiveGame(cancellationToken);

                if (game.Players.Count == 1)
                    return game.Players.FirstOrDefault()!.Name;

                var playersInTurnOrder = game.Players.OrderBy(x => x.TurnOrder).ToList();
                foreach (var player in playersInTurnOrder)
                {
                    if (player.Throws.Count < 2)
                    {
                        return player.Name;
                    }

                    if (player.Throws.Count % 2 != 0)
                    {
                        return player.Name;
                    }

                    if (player.TurnOrder != 1)
                    {
                        var previousPlayer = playersInTurnOrder.FirstOrDefault(x => x.TurnOrder == player.TurnOrder - 1);
                        if (previousPlayer!.Throws.Count > player.Throws.Count)
                            return player.Name;
                    }
                }

                return playersInTurnOrder.FirstOrDefault()!.Name;
            }
        }
    }
}
