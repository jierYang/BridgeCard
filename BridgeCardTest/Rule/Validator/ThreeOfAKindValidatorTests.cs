using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class ThreeOfAKindValidatorTests
    {
        private readonly ThreeOfAKindTypeValidator _typeValidator = new ThreeOfAKindTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateThreeOfAKindCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateThreeOfAKindCards();
            
            var other = CardsBuilder.CreateThreeOfAKindCards();

            //Act
            var result = _typeValidator.CompareSameTypeCards(cards, other);

            //Assert
            Assert.Equal(ComparedResult.Tie, result);
        }
    }
}