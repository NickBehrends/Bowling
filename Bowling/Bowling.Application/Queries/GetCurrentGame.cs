using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Bowling.Application.AggregateModels;
using Bowling.Application.DomainModels;
using Bowling.Application.Repositories;
using MediatR;

namespace Bowling.Application.Queries
{
    public class GetCurrentGame
    {
        public record Query : IRequest<Game>;

        public class Handler : IRequestHandler<Query, Game>
        {
            private readonly IBowlingQueriesRepository _queryRepository;

            public Handler(IBowlingQueriesRepository queryRepository)
            {
                _queryRepository = queryRepository;
            }

            public async Task<Game> Handle(Query request, CancellationToken cancellationToken)
            {
                await Guard.Against.NoGameInProgress(_queryRepository, cancellationToken);
                var gameData = await _queryRepository.GetActiveGame(cancellationToken);

                foreach (var player in gameData.Players)
                {
                    var game = new GameDomainModel();
                    foreach (var pins in player.Throws)
                    {
                        game.Knocked(pins);
                    }

                    player.Frames = game.Frames;
                }

                return gameData;
            }
        }
    }
}
