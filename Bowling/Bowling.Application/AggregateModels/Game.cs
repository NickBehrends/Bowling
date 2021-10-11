using System;
using System.Collections.Generic;

namespace Bowling.Application.AggregateModels
{
    public record Game(string Name, Guid Id, ICollection<Player> Players, int Round);
}