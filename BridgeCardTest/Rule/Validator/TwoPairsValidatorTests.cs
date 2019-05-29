using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class TwoPairsValidatorTests
    {
        private readonly TwoPairsTypeValidator _typeValidator = new TwoPairsTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateTwoPairsCards();

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
            var cards = CardsBuilder.CreateTwoPairsCards();
            
            var other = CardsBuilder.CreateTwoPairsCards();

            //Act
            var result = _typeValidator.CompareSameTypeCards(cards, other);

            //Assert
            Assert.Equal(ComparedResult.Tie, result);
        }
    }
}