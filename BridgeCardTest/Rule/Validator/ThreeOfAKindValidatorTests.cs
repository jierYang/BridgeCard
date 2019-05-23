using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class ThreeOfAKindValidatorTests
    {
        private readonly ThreeOfAKindValidator _validator = new ThreeOfAKindValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateThreeOfAKindCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateThreeOfAKindCards();

            //Act
            var points = _validator.CalculatePoints(cards);

            //Assert
            Assert.Equal(3, points);
        }
    }
}