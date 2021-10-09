namespace Bowling.Application.DomainModels
{
    public class Throw
    {
        public Throw(int index, int pins)
        {
            Index = index;
            Pins = pins;
        }

        public int Index { get; init; }
        public int Pins { get; init; }
    }
}
