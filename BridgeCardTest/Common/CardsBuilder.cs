using System.Collections.Generic;
using BridgeCard;
using BridgeCard.Player;

namespace BridgeCardTest.Common
{
    public static class CardsBuilder
    {
        public static HandCards CreateStraightFlushCards()
        {
            var cards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('6', 'D'),
                new Card('4', 'D'),
                new Card('5', 'D')
            };

            return new HandCards(cards, Role.Black);
        }

        public static HandCards CreateHighCardCards()
        {
            var cards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('7', 'S'),
                new Card('4', 'H'),
                new Card('5', 'C')
            };

            return new HandCards(cards, Role.Black);
        }

        public static HandCards CreateFourOfAKindCards()
        {
            var cards = new List<Card>
            {
                new Card('2', 'A'),
                new Card('3', 'A'),
                new Card('3', 'D'),
                new Card('3', 'A'),
                new Card('3', 'A')
            };

            return new HandCards(cards, Role.Black);
        }
    }
}