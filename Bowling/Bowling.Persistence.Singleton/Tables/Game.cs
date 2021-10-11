using System;
using System.Collections.Generic;

namespace Bowling.Persistence.Singleton.Tables
{
    public record Game(Guid Id, string Name, ICollection<Player> Players, bool IsActive, int Round = 1);

    public record Player(Guid Id, string Name, ICollection<Throw> Throws, bool IsGameCompleted, int TurnOrder);

    public record Throw(int Pins);
}
