using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FlushValidatorTests
    {
        private readonly FlushTypeValidator _typeValidator = new FlushTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFlushHandCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateHighCardHandCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }

        [Fact]
        public void ShouldCorrectCompareSameTypeCards()
        {
            //Arrange
            var cards = CardsBuilder.CreateFlushHandCards();
            var other = CardsBuilder.CreateFlushHandCards();

            //Act
            var result = _typeValidator.CompareSameTypeCards(cards,other);

            //Assert
            Assert.Equal(ComparedResult.Tie, result);
        }
    }
}