using System.Collections.Generic;
using System.Linq;
using BridgeCard;
using BridgeCard.Rule;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule
{
    public class EvaluatorTests
    {
        private readonly Evaluator _evaluator;

        public EvaluatorTests()
        {
            _evaluator = new Evaluator(new List<IValidator>()
            {
                new HighCardValidator(),
                new StraightFlushValidator(),
            });
        }

        [Fact]
        public void StraightFlushCardAndHighCardsShouldGetStraightFlushWins()
        {
            var result = _evaluator.EvaluateCardsWinner(CardsBuilder.CreateStraightFlushCards(),
                CardsBuilder.CreateHighCardCards());

            Assert.Equal("Black wins - Straight flush", result);
        }

        [Fact]
        public void BothHighCardsShouldGetMaxWin()
        {
            var whiteCards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('7', 'S'),
                new Card('4', 'H'),
                new Card('5', 'C')
            };

            var blackCards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('A', 'S'),
                new Card('4', 'H'),
                new Card('5', 'C')
            };

            var result = _evaluator.EvaluateCardsWinner(blackCards, whiteCards);

            Assert.Equal("Black wins - High Card", result);
        }
        
        [Fact]
        public void SameCardsShouldGetTie()
        {
            var cards = CardsBuilder.CreateStraightFlushCards();
            
            var result = _evaluator.EvaluateCardsWinner(cards, cards);

            Assert.Equal("Tie", result);
        }
    }
}