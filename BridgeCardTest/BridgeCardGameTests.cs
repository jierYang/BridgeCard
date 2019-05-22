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
        public void ShouldInitBlackAndWhiteCard()
        {
            //Arrange
            var blackCards = "2H 3D 5S 9C KD";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            _bridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal(CardColor.Heart, _bridgeCardGame.BlackCards.First().CardColor);
            Assert.Equal('2', _bridgeCardGame.BlackCards.First().CardNumber.Number);

            Assert.Equal(CardColor.Heart, _bridgeCardGame.WhiteCards.Last().CardColor);
            Assert.Equal('A', _bridgeCardGame.WhiteCards.Last().CardNumber.Number);
        }
        
        [Fact]
        public void ShouldGetGameResult()
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
            var cards = "5H 3H 2H 4H 6H";

            //Act
            var result = _bridgeCardGame.GetGameResult(cards, cards);

            //Assert
            Assert.Equal("Tie",result);
        }
    }
}