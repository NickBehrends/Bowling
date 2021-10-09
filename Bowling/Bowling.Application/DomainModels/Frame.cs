using System.Collections.Generic;

namespace Bowling.Application.DomainModels
{
    public class Frame
    {
        public Frame(int index, ICollection<Throw> throws)
        {
            Index = index;
            Throws = throws;
        }

        public int Index { get; init; }
        public ICollection<Throw> Throws { get; init; }
        public int Score { get; set; }
    }
}
