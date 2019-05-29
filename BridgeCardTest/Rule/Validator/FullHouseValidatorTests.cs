using System.Linq;
using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FullHouseValidatorTests
    {
        private readonly FullHouseTypeValidator _typeValidator = new FullHouseTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFullHouseHandCards();

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
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateFourOfAKindHandCards();

            var other = CardsBuilder.CreateFourOfAKindHandCards();

            //Act
            var result = _typeValidator.CompareSameTypeCards(cards, other);

            //Assert
            Assert.Equal(ComparedResult.Tie, result);
        }
    }
}