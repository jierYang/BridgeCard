using System.Linq;
using BridgeCard;
using Xunit;

namespace BridgeCardTest
{
    public class BridgeCardGameTests
    {
        private readonly BridgeCardGame _bridgeCardGame;

        public BridgeCardGameTests()
        {
            _bridgeCardGame = new BridgeCardGame();
        }

        [Fact]
        public void ShouldInitBlackAndWhitePlayer()
        {
            //Arrange
            var blackCards = "2H 3D 5S 9C KD";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            var firstBlackCard = _bridgeCardGame.BlackHandCards.Cards.First();
            Assert.Equal(CardColor.Heart, firstBlackCard.CardColor);
            Assert.Equal('2', firstBlackCard.CardNumber.Number);

            var lastWhiteCard = _bridgeCardGame.WhiteHandCards.Cards.Last();            
            Assert.Equal(CardColor.Heart, lastWhiteCard.CardColor);
            Assert.Equal('A', lastWhiteCard.CardNumber.Number);
        }
        
        [Fact]
        public void ShouldGetCorrectGameResult()
        {
            //Arrange
            var blackCards = "5H 3H 2H 4H 6H";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            var result = _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal("Black wins - Straight flush",result);
        }
        
        [Fact]
        public void ShouldGetGameResultTie()
        {
            //Arrange
            var blackCards = "2H 3D 5S 9C KD";

            var whiteCard = "2D 3H 5C 9S KH";

            //Act
            var result = _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal("Tie",result);
        }
        
        [Fact]
        public void ShouldGetGameResultOfFullHouse()
        {
            //Arrange
            var blackCards = "2H 4S 4C 2D 4H";

            var whiteCard = "2S 8S AS QS 3S";

            //Act
            var result = _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal("Black wins - Full House",result);
        }
        
        [Fact]
        public void ShouldGetGameResultOfHighCardAce()
        {
            //Arrange
            var blackCards = "2H 3D 5S 9C KD";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            var result = _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal("White wins - High Card: Ace",result);
        }
    }
}