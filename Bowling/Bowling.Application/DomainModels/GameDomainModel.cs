using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Application.DomainModels
{
    public class GameDomainModel
    {
        public int Score => ScoreForFrame(_currentFrame);
        public ICollection<Frame> Frames { get; set; }

        private readonly List<Throw> _throws;
        private ICollection<Throw> _newThrows;

        private int _currentFrame;
        private int _ball;
        private bool _firstThrowInFrame = true;

        public GameDomainModel()
        {
            Frames = new List<Frame>();
            _throws = new List<Throw>();
            _newThrows = new List<Throw>();
        }

        public void Knocked(int pins)
        {
            _newThrows.Add(new Throw(_newThrows.Count + _throws.Count, pins));
            AdjustCurrentFrame(pins);
        }

        public int ScoreForFrame(int frame)
        {
            _ball = 0;
            var score = 0;

            for (var currentFrame = 0; currentFrame < frame; currentFrame++)
            {
                if (Strike())
                    score += 10 + NextTwoBalls();
                else if (Spare())
                    score += 10 + NextBall();
                else
                    score += TwoBallsInFrame();
            }

            Frames.OrderByDescending(x => x.Index).FirstOrDefault()!.Score = score;
            return score;
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (_firstThrowInFrame)
            {
                if (AdjustFrameForStrike(pins)) 
                    return;

                _firstThrowInFrame = false;
                CommitThrows();
            }
            else
            {
                _firstThrowInFrame = true;
                AdvanceFrame();
            }
        }

        private void CommitThrows()
        {
            _throws.AddRange(_newThrows);
            Frames.Add(new Frame(Frames.Count, _newThrows));
            _newThrows = new List<Throw>();
        }

        private void AdvanceFrame()
        {
            CommitThrows();
            _currentFrame = Math.Min(10, _currentFrame + 1);
        }

        private bool AdjustFrameForStrike(int pins)
        {
            if (pins != 10)
                return false;

            AdvanceFrame();
            return true;
        }

        private bool Spare()
        {
            if (_throws.FirstOrDefault(x => x.Index == _ball)!.Pins +
                _throws.FirstOrDefault(x => x.Index == _ball + 1)!.Pins != 10)
                return false;

            _ball += 2;
            return true;
        }

        private bool Strike()
        {
            if (_throws.FirstOrDefault(x => x.Index == _ball)!.Pins != 10)
                return false;

            _ball++;
            return true;
        }

        private int NextBall()
        {
            return _throws.FirstOrDefault(x => x.Index == _ball)!.Pins;
        }

        private int NextTwoBalls()
        {
            return _throws.FirstOrDefault(x => x.Index == _ball)!.Pins +
                   _throws.FirstOrDefault(x => x.Index == _ball + 1)!.Pins;
        }

        private int TwoBallsInFrame()
        {
            var firstThrow = _throws.FirstOrDefault(x => x.Index == _ball);
            _ball++;
            var secondThrow = _throws.FirstOrDefault(x => x.Index == _ball);
            _ball++;
            return firstThrow!.Pins + secondThrow!.Pins;
        }
    }
}
