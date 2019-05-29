using BridgeCard;
using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class StraightFlushValidatorTests
    {
        private readonly StraightFlushTypeValidator _typeValidator = new StraightFlushTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightFlushHandCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void WhenNotSameColorShouldReturnFalse()
        {
            //Arrange
            var cards = new HandCards("2A 3A 6D 4A 5A");

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = new HandCards("2A 3A 7A 4A 5A");

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightFlushHandCards();
            
            var other = CardsBuilder.CreateStraightFlushHandCards();
            
            //Act
            var result = _typeValidator.CompareSameTypeCards(cards, other);

            //Assert
            Assert.Equal(ComparedResult.Tie, result);
        }
    }
}