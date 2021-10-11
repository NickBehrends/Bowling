using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Bowling.Application.Repositories;
using MediatR;

namespace Bowling.Application
{
    public class ThrowBall
    {
        public record Command(string Player, int Pins) : IRequest;

        public class Handler : IRequestHandler<Command>
        {

            private readonly IBowlingCommandsRepository _commandRepository;
            private readonly IBowlingQueriesRepository _queriesRepository;

            public Handler(IBowlingCommandsRepository commandRepository, IBowlingQueriesRepository queriesRepository)
            {
                _commandRepository = commandRepository;
                _queriesRepository = queriesRepository;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Guard.Against.TooManyPinsKnocked(request.Pins);
                await Guard.Against.UserNotFound(request.Player, _queriesRepository, cancellationToken);

                await _commandRepository.ThrowBall(request, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
