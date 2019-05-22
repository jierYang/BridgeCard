using System.Collections.Generic;
using BridgeCard;
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
            var cards = new HandCards(new List<Card>
            {
                new Card('2', 'A'),
                new Card('3', 'A'),
                new Card('2', 'D'),
                new Card('3', 'A'),
                new Card('3', 'A')
            });

            //Act
            var isSatisfied = _validator.IsSatisfied(cards);

            //Assert
            Assert.Equal(false, isSatisfied);
        }
    }
}