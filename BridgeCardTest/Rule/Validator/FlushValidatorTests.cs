using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FlushValidatorTests : IValidatorTests
    {
        public IValidator Validator { get; } = new FlushValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFlushHandCards();

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
            var cards = CardsBuilder.CreateFlushHandCards();

            //Act
            var points = Validator.CalculatePoints(cards);

            //Assert
            Assert.Equal(10, points);
        }
    }
}