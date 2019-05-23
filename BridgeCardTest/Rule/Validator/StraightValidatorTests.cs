using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class StraightValidatorTests
    {
        private readonly StraightValidator _validator = new StraightValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFullHouseHandCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateStraightCards();

            //Act
            var points = _validator.CalculatePoints(cards);

            //Assert
            Assert.Equal(6, points);
        }
    }
}