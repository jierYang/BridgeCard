using Autofac;
using BridgeCard;
using BridgeCard.Player;
using BridgeCard.Rule;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule
{
    public class DemandTests
    {
        private readonly IDemand _demand;

        public DemandTests()
        {
            var testBase = new Dependency();

            _demand = testBase.Container.BeginLifetimeScope().Resolve<IDemand>();
        }

        [Fact]
        public void StraightFlushCardAndHighCardsShouldGetStraightFlushWins()
        {
            var blackCards = CardsBuilder.CreateStraightFlushHandCards();
            var blackPlayer = new Player(blackCards, Role.Black);

            var whiteCards = CardsBuilder.CreateHighCardHandCards();
            var whitePlayer = new Player(whiteCards, Role.White);

            var result = _demand.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - Straight flush", result);
        }

        [Fact]
        public void BothHighCardsShouldGetMaxWin()
        {
            var whitePlayer = new Player(new HandCards("2D 3D 7S 4H 5C"), Role.White);

            var blackPlayer = new Player(new HandCards("2D 3D AS 4H 5C"), Role.Black);

            var result = _demand.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - High Card", result);
        }

        [Fact]
        public void SameCardsShouldGetTie()
        {
            var cards = CardsBuilder.CreateStraightFlushHandCards();

            var blackPlayer = new Player(cards, Role.Black);

            var whitePlayer = new Player(cards, Role.White);

            var result = _demand.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Tie", result);
        }

        [Fact]
        public void FourOfAKindAndHighCardsShouldGetFourOfAKindWins()
        {
            var blackCards = CardsBuilder.CreateFourOfAKindHandCards();
            var blackPlayer = new Player(blackCards, Role.Black);

            var whiteCards = CardsBuilder.CreateHighCardHandCards();
            var whitePlayer = new Player(whiteCards, Role.White);

            var result = _demand.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - Four of a kind ", result);
        }
    }
}