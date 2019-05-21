using System.Collections.Generic;
using BridgeCard;

namespace BridgeCardTest.Common
{
    public static class CardsBuilder
    {
        public static IList<Card> CreateStraightFlushCards()
        {
            var cards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('6', 'D'),
                new Card('4', 'D'),
                new Card('5', 'D')
            };

            return cards;
        }
        
        public static IList<Card> CreateHighCardCards()
        {
            var cards = new List<Card>
            {
                new Card('2', 'D'),
                new Card('3', 'D'),
                new Card('7', 'S'),
                new Card('4', 'H'),
                new Card('5', 'C')
            };

            return cards;
        }
    }
}