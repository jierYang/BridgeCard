using BridgeCard;
using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FourOfAKindValidatorTests : IValidatorTests
    {
        public IValidator Validator { get; } = new FourOfAKindValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFourOfAKindHandCards();

            //Act
            var isSatisfied = Validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = new HandCards("2A 3A 2D 3A 3A");

            //Act
            var isSatisfied = Validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateFourOfAKindHandCards();

            //Act
            var points = Validator.CalculatePoints(cards);

            //Assert
            Assert.Equal(3, points);
        }
    }
}