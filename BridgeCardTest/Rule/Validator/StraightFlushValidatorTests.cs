using System.Collections.Generic;
using System.Linq;
using BridgeCard;
using BridgeCard.Rule;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class StraightFlushValidatorTests
    {
        private readonly StraightFlushValidator _validator;

        public StraightFlushValidatorTests()
        {
            _validator = new StraightFlushValidator();
        }

        [Fact]
        public void ShouldValidateStraightCard()
        {
            //Arrange
            var cards =CardsBuilder.CreateStraightFlushCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }
        
        [Fact]
        public void WhenNotSameColorShouldReturnFalse()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card('2', 'A'),
                new Card('3', 'A'),
                new Card('6', 'D'),
                new Card('4', 'A'),
                new Card('5', 'A')
            };

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void WhenNotStraightShouldReturnFalse()
        {
            //Arrange
            var cards = new List<Card>
            {
                new Card('2', 'A'),
                new Card('3', 'A'),
                new Card('7', 'A'),
                new Card('4', 'A'),
                new Card('5', 'A')
            };

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }
    }
}