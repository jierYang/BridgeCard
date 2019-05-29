using BridgeCard.Rule.Validator;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class HighCardValidatorTests
    {
        private readonly HighCardTypeValidator _typeValidator= new HighCardTypeValidator();

        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateHighCardHandCards();

            //Act
            var isSatisfied = _typeValidator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }

        [Fact]
        public void ShouldCalculateCorrectPints()
        {
            //Arrange
            var cards = CardsBuilder.CreateHighCardHandCards();

           CardsBuilder.CreateFourOfAKindHandCards();
        }
    }
}