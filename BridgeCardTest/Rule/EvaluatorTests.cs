using Autofac;
using BridgeCard;
using BridgeCard.Player;
using BridgeCard.Rule;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule
{
    public class EvaluatorTests
    {
        private readonly IEvaluator _evaluator;

        public EvaluatorTests()
        {
            var testBase = new Dependency();

            _evaluator = testBase.Container.BeginLifetimeScope().Resolve<IEvaluator>();
        }

        [Fact]
        public void StraightFlushCardAndHighCardsShouldGetStraightFlushWins()
        {
            var blackCards = CardsBuilder.CreateStraightFlushHandCards();
            var blackPlayer = new Player(blackCards, Role.Black);

            var whiteCards = CardsBuilder.CreateHighCardHandCards();
            var whitePlayer = new Player(whiteCards, Role.White);

            var result = _evaluator.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - Straight flush", result);
        }

        [Fact]
        public void BothHighCardsShouldGetMaxWin()
        {
            var whitePlayer = new Player(new HandCards("2D 3D 7S 4H 5C"), Role.White);

            var blackPlayer = new Player(new HandCards("2D 3D 8S 4H 5C"), Role.Black);

            var result = _evaluator.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - High Card: 8", result);
        }

        [Fact]
        public void SameCardsShouldGetTie()
        {
            var cards = CardsBuilder.CreateStraightFlushHandCards();

            var blackPlayer = new Player(cards, Role.Black);

            var whitePlayer = new Player(cards, Role.White);

            var result = _evaluator.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Tie", result);
        }

        [Fact]
        public void FourOfAKindAndHighCardsShouldGetFourOfAKindWins()
        {
            var blackCards = CardsBuilder.CreateFourOfAKindHandCards();
            var blackPlayer = new Player(blackCards, Role.Black);

            var whiteCards = CardsBuilder.CreateHighCardHandCards();
            var whitePlayer = new Player(whiteCards, Role.White);

            var result = _evaluator.EvaluateCardsWinner(blackPlayer, whitePlayer);

            Assert.Equal("Black wins - Four of a kind ", result);
        }
    }
}