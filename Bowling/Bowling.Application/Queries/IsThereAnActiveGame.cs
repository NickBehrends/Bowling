using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.Repositories;
using MediatR;

namespace Bowling.Application.Queries
{
    public class IsThereAnActiveGame
    {
        public record Query : IRequest<bool>;

        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly IBowlingQueriesRepository _queryRepository;

            public Handler(IBowlingQueriesRepository queryRepository)
            {
                _queryRepository = queryRepository;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _queryRepository.DoesActiveGameExist(cancellationToken);
            }
        }
    }
}
