using System.Collections.Generic;
using System.Linq;
using BridgeCard;
using BridgeCard.Player;
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
            var cards = CardsBuilder.CreateStraightFlushCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void WhenNotSameColorShouldReturnFalse()
        {
            //Arrange
            var cards = new HandCards("2A 3A 6D 4A 5A");

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void WhenNotStraightShouldReturnFalse()
        {
            //Arrange
            var cards = new HandCards("2A 3A 7A 4A 5A");

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }
    }
}