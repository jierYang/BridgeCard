using System.Collections.Generic;
using BridgeCard;
using BridgeCard.Player;
using BridgeCard.Rule;
using BridgeCardTest.Common;
using Xunit;

namespace BridgeCardTest.Rule.Validator
{
    public class FourOfAKindValidatorTests
    {
        private readonly FourOfAKindValidator _validator;

        public FourOfAKindValidatorTests()
        {
            _validator = new FourOfAKindValidator();
        }
        
        [Fact]
        public void ShouldValidateSatisfy()
        {
            //Arrange
            var cards = CardsBuilder.CreateFourOfAKindCards();

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(true, isSatisfied);
        }
        
        [Fact]
        public void ShouldValidateNotSatisfy()
        {
            //Arrange
            var cards = new HandCards("2A 3A 2D 3A 3A");

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }
    }
}