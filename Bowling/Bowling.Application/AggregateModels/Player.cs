using System;
using System.Collections.Generic;

namespace Bowling.Application.AggregateModels
{
    public record Player(string Name, Guid Id, ICollection<int> Throws, int Score, int TurnOrder)
    {
        public ICollection<Frame> Frames { get; set; }
    }
}