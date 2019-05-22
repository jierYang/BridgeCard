using System.Collections.Generic;
using BridgeCard;
using BridgeCard.Player;

namespace BridgeCardTest.Common
{
    public static class CardsBuilder
    {
        public static HandCards CreateStraightFlushCards()
        {
            return new HandCards("2D 3D 6D 4D 5D");
        }

        public static HandCards CreateHighCardCards()
        {
            return new HandCards("2D 3D 7S 4H 5C");
        }

        public static HandCards CreateFourOfAKindCards()
        {
            return new HandCards("2A 3A 3D 3A 3A");
        }
    }
}