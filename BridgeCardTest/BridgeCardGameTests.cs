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
            Assert.Equal(ColorType.Heart, BridgeCardGame.BlackCards.First().ColorType);
            Assert.Equal('2', BridgeCardGame.BlackCards.First().Number);

            Assert.Equal(ColorType.Heart, BridgeCardGame.WhiteCards.Last().ColorType);
            Assert.Equal('A', BridgeCardGame.WhiteCards.Last().Number);
        }
    }
}