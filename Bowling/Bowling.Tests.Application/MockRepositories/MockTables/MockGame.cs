using System;
using System.Collections.Generic;

namespace Bowling.Tests.Application.MockRepositories.MockTables
{
    public record MockGame(Guid Id, string Name, ICollection<string> Players);
}