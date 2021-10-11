using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bowling.Application.Exceptions;
using Bowling.Application.Repositories;

namespace Ardalis.GuardClauses
{
    public static class AlreadyAnActiveGame
    {
        public static async Task GameAlreadyInProgress(this IGuardClause guardClause, 
            IBowlingQueriesRepository queriesRepository, CancellationToken? cancellationToken = null)
        {
            if (await queriesRepository.DoesActiveGameExist(cancellationToken))
                throw new GameAlreadyInProgressException();
        }

        public static async Task NoGameInProgress(this IGuardClause guardClause,
            IBowlingQueriesRepository queriesRepository, CancellationToken? cancellationToken = null)
        {
            if (!await queriesRepository.DoesActiveGameExist(cancellationToken))
                throw new NoGameInProgressException();
        }

        public static void TooManyPinsKnocked(this IGuardClause guardClause, int pinsKnocked)
        {
            if (pinsKnocked > 10)
                throw new TooManyPinsKnockedException();
        }

        public static async Task UserNotFound(this IGuardClause guardClause, string player,
            IBowlingQueriesRepository queriesRepository, CancellationToken? cancellationToken = null)
        {
            if (!await queriesRepository.DoesUserExist(player, cancellationToken))
                throw new UserNotFoundException();
        }

        public static void Duplicates(this IGuardClause guardClause, ICollection<string> players)
        {
            if (players.Count != players.Distinct().Count())
                throw new DuplicateNameException();
        }
    }
}
