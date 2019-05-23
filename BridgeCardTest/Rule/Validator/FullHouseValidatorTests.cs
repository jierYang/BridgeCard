using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FullHouseValidatorTests : IValidatorTests
    {
        public IValidator Validator { get; } = new FullHouseValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFullHouseHandCards();

            //Act
            var isSatisfied = Validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }
        
        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateHighCardHandCards();

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