using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application.AggregateModels;
using Xunit;
using Game = Bowling.Application.DomainModels.GameDomainModel;

namespace Bowling.Tests.Application
{
    public class GameDomainModelTests
    {
        [Fact]
        public void TwoThrowsNoStrike()
        {
            var game = new Game();
            game.Knocked(5);
            game.Knocked(4);
            Assert.Equal(9, game.Score);
        }

        [Fact]
        public void FourThrowsNoStrike()
        {
            var game = new Game();
            game.Knocked(5);
            game.Knocked(4);
            game.Knocked(7);
            game.Knocked(2);
            Assert.Equal(18, game.Score);
            Assert.Equal(9, game.ScoreForFrame(1));
            Assert.Equal(18, game.ScoreForFrame(2));
        }

        [Fact]
        public void SimpleSpare()
        {
            var game = new Game();
            game.Knocked(3);
            game.Knocked(7);
            game.Knocked(3);
            game.Knocked(2);
            Assert.Equal(13, game.ScoreForFrame(1));
            Assert.Equal(18, game.ScoreForFrame(2));
        }

        [Fact]
        public void FrameAfterSimpleSpare()
        {
            var game = new Game();
            game.Knocked(3);
            game.Knocked(7);
            game.Knocked(3);
            game.Knocked(2);
            Assert.Equal(13, game.ScoreForFrame(1));
            Assert.Equal(18, game.Score);
        }

        [Fact]
        public void SimpleStrike()
        {
            var game = new Game();
            game.Knocked(10);
            game.Knocked(3);
            game.Knocked(6);
            Assert.Equal(19, game.ScoreForFrame(1));
            Assert.Equal(28, game.Score);
        }

        [Fact]
        public void PerfectGame()
        {
            var game = new Game();
            for (var i = 0; i < 12; i++)
            {
                game.Knocked(10);
            }
            Assert.Equal(300, game.Score);
        }

        [Fact]
        public void SampleGame()
        {
            //First result from google images
            var game = new Game();
            game.Knocked(10);
            game.Knocked(9);
            game.Knocked(1);
            game.Knocked(5);
            game.Knocked(5);
            game.Knocked(7);
            game.Knocked(2);
            game.Knocked(10);
            game.Knocked(10);
            game.Knocked(10);
            game.Knocked(9);
            game.Knocked(0);
            game.Knocked(8);
            game.Knocked(2);
            game.Knocked(9);
            game.Knocked(1);
            game.Knocked(10);

            Assert.Equal(187, game.Score);
        }

        [Fact]
        public void AlmostPerfectGame()
        {
            var game = new Game();
            for (var i = 0; i < 11; i++)
                game.Knocked(10);
            game.Knocked(9);
            Assert.Equal(299, game.Score);
        }

        [Fact]
        public void TenthFrameSpare()
        {
            var game = new Game();
            for (var i = 0; i < 9; i++)
                game.Knocked(10);
            game.Knocked(9);
            game.Knocked(1);
            game.Knocked(1);
            Assert.Equal(270, game.Score);
        }
    }
}