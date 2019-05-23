using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class TwoPairsValidatorTests
    {
        private readonly TwoPairsValidator _validator = new TwoPairsValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateTwoPairsCards();

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
            var cards = CardsBuilder.CreateTwoPairsCards();

            //Act
            var points = _validator.CalculatePoints(cards);

            //Assert
            Assert.Equal(11, points);
        }
    }
}