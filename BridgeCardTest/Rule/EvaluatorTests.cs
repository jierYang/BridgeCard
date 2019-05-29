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
          
            var whiteCards = CardsBuilder.CreateHighCardHandCards();

            var result = _evaluator.EvaluateCardsWinner(blackCards, whiteCards);

            Assert.Equal(GameResult.BlackWin, result);
        }

        [Fact]
        public void BothHighCardsShouldGetMaxWin()
        {
            var blackCards = new HandCards("2D 3D 7S 4H 5C");
            
            var whiteCards = new HandCards("2D 3D AS 4H 5C");

            var result = _evaluator.EvaluateCardsWinner(blackCards, whiteCards);

            Assert.Equal(GameResult.WhiteWin, result);
        }

        [Fact]
        public void SameCardsShouldGetTie()
        {
            var cards = CardsBuilder.CreateStraightFlushHandCards();

            var result = _evaluator.EvaluateCardsWinner(cards, cards);

            Assert.Equal(GameResult.Tie, result);
        }

        [Fact]
        public void FourOfAKindAndHighCardsShouldGetFourOfAKindWins()
        {
            var blackCards = CardsBuilder.CreateFourOfAKindHandCards();

            var whiteCards = CardsBuilder.CreateHighCardHandCards();

            var result = _evaluator.EvaluateCardsWinner(blackCards, whiteCards);

            Assert.Equal(GameResult.BlackWin, result);
        }
    }
}