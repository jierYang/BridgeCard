using System.Linq;
using BridgeCard;
using Xunit;

namespace BridgeCardTest
{
    public class Class1
    {
        private readonly BridgeCardGame BridgeCardGame;

        public Class1()
        {
            BridgeCardGame = new BridgeCardGame();
        }

        [Fact]
        public void ShouldInitBlackAndWhiteCard()
        {
            //Arrange
            var blackCards = "2H 3D 5S 9C KD";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            BridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal(CardColor.Heart, BridgeCardGame.BlackCards.First().CardColor);
            Assert.Equal('2', BridgeCardGame.BlackCards.First().CardNumber.Number);

            Assert.Equal(CardColor.Heart, BridgeCardGame.WhiteCards.Last().CardColor);
            Assert.Equal('A', BridgeCardGame.WhiteCards.Last().CardNumber.Number);
        }
        
        [Fact]
        public void ShouldGetGameResult()
        {
            //Arrange
            var blackCards = "5H 3H 2H 4H 6H";

            var whiteCard = "2C 3H 4S 8C AH";

            //Act
            var result = BridgeCardGame.GetGameResult(blackCards, whiteCard);

            //Assert
            Assert.Equal("Black wins - Straight flush",result);
        }
    }
}