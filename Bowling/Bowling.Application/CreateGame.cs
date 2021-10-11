using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Bowling.Application.Repositories;
using MediatR;

namespace Bowling.Application
{
    public class CreateGame
    {
        public record Command(string GameName, ICollection<string> Players) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IBowlingCommandsRepository _commandRepository;
            private readonly IBowlingQueriesRepository _queriesRepository;

            public Handler(IBowlingCommandsRepository commandRepository, IBowlingQueriesRepository queriesRepository)
            {
                _commandRepository = commandRepository;
                _queriesRepository = queriesRepository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                Guard.Against.NullOrWhiteSpace(request.GameName, nameof(request.GameName));
                Guard.Against.NullOrEmpty(request.Players, nameof(request.Players)); 
                foreach (var player in request.Players)
                    Guard.Against.NullOrWhiteSpace(player, nameof(player));
                Guard.Against.Duplicates(request.Players);
                await Guard.Against.GameAlreadyInProgress(_queriesRepository, cancellationToken);

                var gameId = Guid.NewGuid();

                await _commandRepository.CreateGame(
                    id: gameId, 
                    name: request.GameName, 
                    players: request.Players, 
                    cancellationToken: cancellationToken);

                return gameId;
            }
        }
    }
}
